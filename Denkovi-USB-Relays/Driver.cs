//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Switch driver for DenkoviUSB
//
// Description:	Supports a single 8-Relay Denkovi board with USB interface.
//              The relay labels can be defined at Setup time, the are kept in the ASCOM profile.
//              The driver can (optionally) monitor the status of the relays and save it in the profile.
//                If such monitoring is enabled (via Setup), the last known-as-good state will be enforced
//                onto the board at Connect time.
//
// Implements:	ASCOM Switch interface version: 6.2
// Author:		(AB) Arie Blumenzweig <blumzi@013.net>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 20-Aug-2016	AB 	6.0.0	Initial edit, created from ASCOM driver template
// --------------------------------------------------------------------------------
//


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define Switch

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;

using FTD2XX_NET;

namespace ASCOM.DenkoviUSB
{
    //
    // Your driver's DeviceID is ASCOM.DenkoviUSB.Switch
    //
    // The Guid attribute sets the CLSID for ASCOM.DenkoviUSB.Switch
    // The ClassInterface/None addribute prevents an empty interface called
    // _DenkoviUSB from being created and used as the [default] interface
    //
    // TODO Replace the not implemented exceptions with code to implement the function or
    // throw the appropriate ASCOM exception.
    //

    /// <summary>
    /// ASCOM Switch Driver for DenkoviUSB.
    /// </summary>
    [Guid("1b37084d-2559-445a-8f31-33656f141518")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Switch : ISwitchV2
    {
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.DenkoviUSB.Switch";
        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        private static string driverDescription = "ASCOM Switch Driver for an 8-Relay DenkoviUSB board.";

        internal static string ftdiIndexProfileName = "FTDI Index"; // Constants used for Profile persistence
        internal static string ftdiIndexDefault = "0";
        internal static string traceStateProfileName = "Trace Level";
        internal static string traceStateDefault = "false";

        internal static uint ftdiIndex; // Variables to hold the currrent device configuration
        internal static bool traceState;

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool _connected;
        private System.Windows.Forms.Timer relaysStateTimer = new System.Windows.Forms.Timer();

        public static string[] relayLabels;
        private int relaysState = -1;

        internal static string persistantRelaysProfileName = "Save and restore relays state";
        private bool persistantRelays = true;

        /// <summary>
        /// Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
        /// </summary>
        private TraceLogger tl;

        public FTDI _device = new FTDI();

        /// <summary>
        /// Initializes a new instance of the <see cref="DenkoviUSB"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Switch()
        {
            tl = new TraceLogger("", "DenkoviUSB");
            tl.Enabled = traceState;
            tl.LogMessage("Switch", "Starting initialisation");

            relayLabels = new string[numSwitch];
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            _connected = false; // Initialise connected to false

            tl.LogMessage("Switch", "Completed initialisation");
        }


        //
        // PUBLIC COM INTERFACE ISwitchV2 IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (IsConnected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press OK");

            using (SetupDialogForm F = new SetupDialogForm())
            {
                var result = F.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                }
            }
        }

        public ArrayList SupportedActions
        {
            get
            {
                tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                return new ArrayList();
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");
        }

        public void CommandBlind(string command, bool raw)
        {
            CheckConnected("CommandBlind");
            // Call CommandString and return as soon as it finishes
            //this.CommandString(command, raw);
            // or
            throw new ASCOM.MethodNotImplementedException("CommandBlind");
            // DO NOT have both these sections!  One or the other
        }

        public bool CommandBool(string command, bool raw)
        {
            CheckConnected("CommandBool");
            //string ret = CommandString(command, raw);
            // TODO decode the return string and return true or false
            // or
            throw new ASCOM.MethodNotImplementedException("CommandBool");
            // DO NOT have both these sections!  One or the other
        }

        public string CommandString(string command, bool raw)
        {
            CheckConnected("CommandString");
            // it's a good idea to put all the low level communication with the device here,
            // then all communication calls this function
            // you need something to ensure that only one command is in progress at a time

            throw new ASCOM.MethodNotImplementedException("CommandString");
        }

        public void Dispose()
        {
            // Clean up the tracelogger and util objects
            tl.Enabled = false;
            tl.Dispose();
            tl = null;
        }

        private bool AskForStatus()
        {
            byte[] obuf = Encoding.ASCII.GetBytes("ask//");
            byte[] ibuf = new byte[2];
            uint nbytes = 0;


            relaysState = -1;
            try
            {
                _device.Write(obuf, obuf.Length, ref nbytes);
                if (nbytes != obuf.Length)
                    throw new InvalidOperationException(string.Format("Could not write \"ask//\" to FTDI{0}", ftdiIndex));
                System.Threading.Thread.Sleep(10);
                _device.Read(ibuf, (uint)ibuf.Length, ref nbytes);
                if (nbytes != ibuf.Length)
                    throw new InvalidOperationException(string.Format("Could not read from FTDI{0}", ftdiIndex));
                relaysState = (ibuf[1] << 8) | ibuf[0];
                return true;
            } catch
            {
                return false;
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (!AskForStatus())
                return;

            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Switch";
                driverProfile.WriteValue(driverID, "State", relaysState.ToString());
            }
        }

        public bool Connected
        {
            get
            {
                tl.LogMessage("Connected Get", IsConnected.ToString());
                return IsConnected;
            }
            set
            {
                FTDI.FT_STATUS status;

                tl.LogMessage("Connected Set", value.ToString());
                if (value == IsConnected)
                    return;

                if (value)
                {
                    _connected = true;
                    tl.LogMessage("Connected Set", "Connecting to FTDI " + ftdiIndex);
                    
                    _device = new FTDI();
                    status = _device.OpenByIndex(ftdiIndex);
                    if (status != FTDI.FT_STATUS.FT_OK)
                        throw new InvalidOperationException(string.Format("Cannot OpenByIndex{0} FTDI{0}.", ftdiIndex));

                    status = _device.SetBaudRate(921600);
                    if (status != FTDI.FT_STATUS.FT_OK)
                        throw new InvalidOperationException(string.Format("Cannot SetBaudRate(921600) on FTDI{0}.", ftdiIndex));

                    status = _device.SetBitMode(255, 4);
                    if (status != FTDI.FT_STATUS.FT_OK)
                        throw new InvalidOperationException(string.Format("Cannot SetBitMode(255, 4) on FTDI{0}.", ftdiIndex));

                    if (persistantRelays)
                    {
                        if (relaysState != -1)
                        {
                            for (short i = 0; i < 8; i++)
                            {
                                SetSwitch(i, (relaysState & (1 << i)) == 0 ? false : true);
                            }
                        }
                        relaysStateTimer.Interval = 5000;
                        relaysStateTimer.Tick += StatusTimer_Tick;
                    }
                }
                else
                {
                    _connected = false;
                    tl.LogMessage("Connected Set", "Disconnecting from FTDI" + ftdiIndex);
                    
                    status = _device.Close();
                    if (status != FTDI.FT_STATUS.FT_OK)
                        throw new InvalidOperationException(string.Format("Cannot Close() FTDI{0}.", ftdiIndex));
                }
            }
        }

        public string Description
        {
            get
            {
                tl.LogMessage("Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                
                string driverInfo = "Single Denkovi-USB-8Relays board driver. Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            // set by the driver wizard
            get
            {
                tl.LogMessage("InterfaceVersion Get", "2");
                return Convert.ToInt16("2");
            }
        }

        public string Name
        {
            get
            {
                string name = "Denkovi USB 8Relays driver";
                tl.LogMessage("Name Get", name);
                return name;
            }
        }

        #endregion

        #region ISwitchV2 Implementation

        private short numSwitch = 8;

        /// <summary>
        /// The number of switches managed by this driver
        /// </summary>
        public short MaxSwitch
        {
            get
            {
                tl.LogMessage("MaxSwitch Get", numSwitch.ToString());
                return this.numSwitch;
            }
        }

        /// <summary>
        /// Return the name of switch n
        /// </summary>
        /// <param name="id">The switch number to return</param>
        /// <returns>
        /// The name of the switch
        /// </returns>
        public string GetSwitchName(short id)
        {
            Validate("GetSwitchName", id);
            tl.LogMessage("GetSwitchName", string.Format("GetSwitchName({0}) - {0}", relayLabels[id]));
            return relayLabels[id];
        }

        /// <summary>
        /// Sets a switch name to a specified value
        /// </summary>
        /// <param name="id">The number of the switch whose name is to be set</param>
        /// <param name="name">The name of the switch</param>
        public void SetSwitchName(short id, string name)
        {
            Validate("SetSwitchName", id);
            relayLabels[id] = name;
            tl.LogMessage("SetSwitchName", string.Format("SetSwitchName({0}) = {1}", id, name));
        }

        /// <summary>
        /// Gets the switch description.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string GetSwitchDescription(short id)
        {
            Validate("GetSwitchDescription", id);
            tl.LogMessage("GetSwitchDescription", string.Format("GetSwitchDescription({0}) - not implemented", id));
            throw new MethodNotImplementedException("GetSwitchDescription");
        }

        /// <summary>
        /// Reports if the specified switch can be written to.
        /// This is false if the switch cannot be written to, for example a limit switch or a sensor.
        /// The default is true.
        /// </summary>
        /// <param name="id">The number of the switch whose write state is to be returned</param><returns>
        ///   <c>true</c> if the switch can be written to, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
        /// <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
        public bool CanWrite(short id)
        {
            Validate("CanWrite", id);
            tl.LogMessage("CanWrite", string.Format("CanWrite({0}) - default true", id));
            return true;
        }

        #region boolean switch members

        /// <summary>
        /// Return the state of switch n
        /// a multi-value switch must throw a not implemented exception
        /// </summary>
        /// <param name="id">The switch number to return</param>
        /// <returns>
        /// True or false
        /// </returns>
        public bool GetSwitch(short id)
        {
            Validate("GetSwitch", id);

            if (!AskForStatus())
                throw new InvalidOperationException("Cannot get relays status");

            return ((relaysState & (1 << id)) == 0) ? false : true;
        }

        /// <summary>
        /// Sets a switch to the specified state
        /// If the switch cannot be set then throws a MethodNotImplementedException.
        /// A multi-value switch must throw a not implemented exception
        /// setting it to false will set it to its minimum value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        public void SetSwitch(short id, bool state)
        {
            Validate("SetSwitch", id);
            if (!CanWrite(id))
            {
                var str = string.Format("SetSwitch({0}) - Cannot Write", id);
                tl.LogMessage("SetSwitch", str);
                throw new MethodNotImplementedException(str);
            }

            uint nbytes = 0;
            string cmd = string.Format("{0:2}{1}//", id, state ? '+' : '-');
            byte[] obuf = Encoding.ASCII.GetBytes(cmd);
            byte[] answer = new byte[5];

            _device.Write(obuf, obuf.Length, ref nbytes);
            if (nbytes != obuf.Length)
                throw new InvalidOperationException(string.Format("Could not send \"{0}\" to FTDI{1}", cmd, ftdiIndex));
            System.Threading.Thread.Sleep(10);
            _device.Read(answer, (uint)answer.Length, ref nbytes);
            if (nbytes != answer.Length)
                throw new InvalidOperationException(string.Format("Could not read from FTDI{0}", ftdiIndex));
            if (answer != obuf)
                throw new InvalidOperationException(string.Format("Bad answer from FTDI{0}, expected \"{1}\" got \"{2|\"!",
                    ftdiIndex, obuf, answer));
        }

        #endregion

        #region analogue members

        /// <summary>
        /// returns the maximum value for this switch
        /// boolean switches must return 1.0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double MaxSwitchValue(short id)
        {
            Validate("MaxSwitchValue", id);
            // boolean switch implementation:
            return 1;
        }

        /// <summary>
        /// returns the minimum value for this switch
        /// boolean switches must return 0.0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double MinSwitchValue(short id)
        {
            Validate("MinSwitchValue", id);
            // boolean switch implementation:
            return 0;
        }

        /// <summary>
        /// returns the step size that this switch supports. This gives the difference between
        /// successive values of the switch.
        /// The number of values is ((MaxSwitchValue - MinSwitchValue) / SwitchStep) + 1
        /// boolean switches must return 1.0, giving two states.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double SwitchStep(short id)
        {
            Validate("SwitchStep", id);
            // boolean switch implementation:
            return 1;
            // or
            //tl.LogMessage("SwitchStep", string.Format("SwitchStep({0}) - not implemented", id));
            //throw new MethodNotImplementedException("SwitchStep");
        }

        /// <summary>
        /// returns the analogue switch value for switch id
        /// boolean switches must throw a not implemented exception
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSwitchValue(short id)
        {
            Validate("GetSwitchValue", id);
            tl.LogMessage("GetSwitchValue", string.Format("GetSwitchValue({0}) - not implemented", id));
            throw new MethodNotImplementedException("GetSwitchValue");
        }

        /// <summary>
        /// set the analogue value for this switch.
        /// If the switch cannot be set then throws a MethodNotImplementedException.
        /// If the value is not between the maximum and minimum then throws an InvalidValueException
        /// boolean switches must throw a not implemented exception.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void SetSwitchValue(short id, double value)
        {
            Validate("SetSwitchValue", id, value);
            if (!CanWrite(id))
            {
                tl.LogMessage("SetSwitchValue", string.Format("SetSwitchValue({0}) - Cannot write", id));
                throw new ASCOM.MethodNotImplementedException(string.Format("SetSwitchValue({0}) - Cannot write", id));
            }
            tl.LogMessage("SetSwitchValue", string.Format("SetSwitchValue({0}) = {1} - not implemented", id, value));
            throw new MethodNotImplementedException("SetSwitchValue");
        }

        #endregion
        #endregion

        #region private methods

        /// <summary>
        /// Checks that the switch id is in range and throws an InvalidValueException if it isn't
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="id">The id.</param>
        private void Validate(string message, short id)
        {
            if (id < 0 || id >= numSwitch)
            {
                tl.LogMessage(message, string.Format("Switch {0} not available, range is 0 to {1}", id, numSwitch - 1));
                throw new InvalidValueException(message, id.ToString(), string.Format("0 to {0}", numSwitch - 1));
            }
        }

        /// <summary>
        /// Checks that the switch id and value are in range and throws an
        /// InvalidValueException if they are not.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="id">The id.</param>
        /// <param name="value">The value.</param>
        private void Validate(string message, short id, double value)
        {
            Validate(message, id);
            var min = MinSwitchValue(id);
            var max = MaxSwitchValue(id);
            if (value < min || value > max)
            {
                tl.LogMessage(message, string.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", id, value, min, max));
                throw new InvalidValueException(message, value.ToString(), string.Format("Switch({0}) range {1} to {2}", id, min, max));
            }
        }

        /// <summary>
        /// Checks that the number of states for the switch is correct and throws a methodNotImplemented exception if not.
        /// Boolean switches must have 2 states and multi-value switches more than 2.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <param name="expectBoolean"></param>
        //private void Validate(string message, short id, bool expectBoolean)
        //{
        //    Validate(message, id);
        //    var ns = (int)(((MaxSwitchValue(id) - MinSwitchValue(id)) / SwitchStep(id)) + 1);
        //    if ((expectBoolean && ns != 2) || (!expectBoolean && ns <= 2))
        //    {
        //        tl.LogMessage(message, string.Format("Switch {0} has the wriong number of states", id, ns));
        //        throw new MethodNotImplementedException(string.Format("{0}({1})", message, id));
        //    }
        //}

        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        #region ASCOM Registration

        // Register or unregister driver for ASCOM. This is harmless if already
        // registered or unregistered. 
        //
        /// <summary>
        /// Register or unregister the driver with the ASCOM Platform.
        /// This is harmless if the driver is already registered/unregistered.
        /// </summary>
        /// <param name="bRegister">If <c>true</c>, registers the driver, otherwise unregisters it.</param>
        private static void RegUnregASCOM(bool bRegister)
        {
            using (var P = new ASCOM.Utilities.Profile())
            {
                P.DeviceType = "Switch";
                if (bRegister)
                {
                    P.Register(driverID, driverDescription);
                }
                else
                {
                    P.Unregister(driverID);
                }
            }
        }

        /// <summary>
        /// This function registers the driver with the ASCOM Chooser and
        /// is called automatically whenever this class is registered for COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is successfully built.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During setup, when the installer registers the assembly for COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually register a driver with ASCOM.
        /// </remarks>
        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        /// <summary>
        /// This function unregisters the driver from the ASCOM Chooser and
        /// is called automatically whenever this class is unregistered from COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is cleaned or prior to rebuilding.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During uninstall, when the installer unregisters the assembly from COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually unregister a driver from ASCOM.
        /// </remarks>
        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }

        #endregion

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool IsConnected
        {
            get
            {
                // TODO check that the driver hardware connection exists and is connected to the hardware
                return _connected;
            }
        }

        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
            {
                throw new ASCOM.NotConnectedException(message);
            }
        }

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Switch";
                traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, string.Empty, traceStateDefault));
                ftdiIndex = Convert.ToUInt32(driverProfile.GetValue(driverID, ftdiIndexProfileName, string.Empty, ftdiIndexDefault));
                for (int i = 0; i < MaxSwitch; i++)
                {
                    relayLabels[i] = driverProfile.GetValue(driverID, "Labels", i.ToString(), "Relay" + i.ToString());
                }
                relaysState = Convert.ToInt16(driverProfile.GetValue(driverID, "State", string.Empty, "-1"));
                persistantRelays = Convert.ToBoolean(driverProfile.GetValue(driverID, persistantRelaysProfileName, string.Empty, true.ToString()));
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Switch";
                driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString());
                driverProfile.WriteValue(driverID, ftdiIndexProfileName, ftdiIndex.ToString());
                for (int i = 0; i < MaxSwitch; i++)
                    driverProfile.WriteValue(driverID, "Labels", relayLabels[i], i.ToString());
                driverProfile.WriteValue(driverID, "State", relaysState.ToString());
                driverProfile.WriteValue(driverID, persistantRelaysProfileName, persistantRelays.ToString());
            }
        }

        public static void SetLabel(int i, string text)
        {
            relayLabels[i] = text;
        }

        #endregion

    }
}

using Rimkus3EServicesHealthCheck.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Setting;
using Terminal.Gui;

namespace Rimkus3EServicesHealthCheck
{
    class Program
    {
        public static UKGTE3EAppSetting _appSetting;
        private static log4net.ILog logger;

        static void Main(string[] args)
        {
            #region configuration application log

            log4net.Config.XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger(typeof(Program));

            #endregion configuration application log

            Application.Init();
            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => {
                    Application.RequestStop ();
                            })
                        }),
                    });

            var win = new Window("RIMKUS 3E TRANSACTION SERVICES HEALTH CHECK")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };


            _appSetting = new UKGTE3EAppSetting(ConfigurationManager.AppSettings);

            // Create input components and labels
            var environmentOptionLabel = new Label()
            {
                Text = "3E ENVIRONMENT:",
                Y = 1
			};

            var environmentOptionComboBox = new ComboBox(new List<string>() { "TE_3E_DEV", "TE_3E_UAT", "TE_3E_STAGING", "TE_3E_PROD" })
            {
                
                //AutoSize = true,
                Width = 14,
                Height = 6,
                HideDropdownListOnClick = true,
                X = Pos.Right(environmentOptionLabel) + 1,
                Y = Pos.Top(environmentOptionLabel)
            };

            environmentOptionComboBox.SelectedItem = _appSetting.RCG3EDbInstance == "TE_3E_DEV" ? 0 :
                                                     _appSetting.RCG3EDbInstance == "TE_3E_UAT" ? 1 :
                                                     _appSetting.RCG3EDbInstance == "TE_3E_STAGING" ? 2 : 3;

            var te3eTransSrvOptionLabel = new Label()
			{
				Text = "PLEASE PICK A TEST TO RUN (CHECK ALL THAT APPLY):",
				Y = Pos.Bottom(environmentOptionComboBox) + 1
			};

            var te3eTransSrvOptionCheckBox1 = new CheckBox()
            {
                X = 1,
                Y = Pos.Bottom(te3eTransSrvOptionLabel),
                Text = "NBI MATTER (MATTER__SRV_RC - ADD)",
                TextAlignment = TextAlignment.Left,
                AutoSize = true,
                Checked = _appSetting.HasMatterSrvAdd
            };

            var te3eTransSrvOptionCheckBox2 = new CheckBox()
            {
                X = 1,
                Y = Pos.Bottom(te3eTransSrvOptionCheckBox1),
                Text = "PURCHASE REQUEST (POREQWF_CCC - ADD))",
                TextAlignment = TextAlignment.Left,
                AutoSize = false,
                Checked = _appSetting.HasPOSrvAdd
            };

            var te3eTransSrvOptionCheckBox3 = new CheckBox()
            {
                X = 1,
                Y = Pos.Bottom(te3eTransSrvOptionCheckBox2),
                Text = "TIMEKEEPER (TIMEKEEPER_SRV - ADD))",
                TextAlignment = TextAlignment.Left,
                AutoSize = false,
                Checked = _appSetting.HasTimekeeperSrvAdd
            };

            var te3eTransSrvOptionCheckBox4 = new CheckBox()
            {
                X = 1,
                Y = Pos.Bottom(te3eTransSrvOptionCheckBox3),
                Text = "USER (NXUSER_SRV - ADD))",
                TextAlignment = TextAlignment.Left,
                AutoSize = false,
                Checked = _appSetting.HasNxUserSrvAdd
            };


            var tv = new TextView()
            {
                Width = Dim.Fill(),
                Height = Dim.Percent(95),
                Y = Pos.Bottom(te3eTransSrvOptionCheckBox4) + 1,
                WordWrap = true,
                ReadOnly = true,
            };

            //te3eTransSrvOptionRadio.SelectedItemChanged += () =>
            //{
            //    //var selectedSrv = te3eTransSrvOptionRadio.SelectedItem
            //    //if (usernameText.Text == "admin" && passwordText.Text == "password")
            //    //{
            //    //	MessageBox.Query("Logging In", "Login Successful", "Ok");
            //    //	Application.RequestStop();
            //    //}
            //    //else
            //    //{
            //    //	MessageBox.ErrorQuery("Logging In", "Incorrect username or password", "Ok");
            //    //}
            //};

            //var usernameText = new TextField("")
            //{
            //    // Position text field adjacent to the label
            //    X = Pos.Right(te3eTransSvrOptionLabel) + 1,

            //    // Fill remaining horizontal space
            //    Width = Dim.Fill(),

            //};

            //var passwordLabel = new Label()
            //{
            //    Text = "Password:",
            //    X = Pos.Left(te3eTransSvrOptionLabel),
            //    Y = Pos.Bottom(te3eTransSvrOptionLabel) + 1
            //};

            //var passwordText = new TextField("")
            //{
            //    Secret = true,
            //    // align with the text box above
            //    X = Pos.Left(usernameText),
            //    Y = Pos.Top(passwordLabel),
            //    Width = Dim.Fill(),
            //};

            // Create login button
            var btnLogin = new Button()
			{
				Text = "PRESS RUN",
				Y = Pos.Top(environmentOptionLabel) + 1,
				// center the login button horizontally
				X = Pos.Center(),
				IsDefault = true,
			};

			// When login button is clicked display a message popup
			btnLogin.Clicked += () => {

                _appSetting.RCG3EDbInstance = environmentOptionComboBox.Text.ToString();
                _appSetting.Te3eServer = environmentOptionComboBox.Text.ToString() == "TE_3E_DEV" ? "dev" 
                                         : environmentOptionComboBox.Text.ToString() == "TE_3E_UAT" ? "uat"
                                         : environmentOptionComboBox.Text.ToString() == "TE_3E_STAGING" ? "staging" 
                                         : "prod";
                TE3ETransactionClient tE3ETransactionClient = new TE3ETransactionClient(_appSetting);
                
                StringBuilder sb = new StringBuilder();
                var headerText = "===========================================================================\n";
                headerText = headerText + "TEST SUMMARY\n";
                headerText = headerText + "===========================================================================\n";
                sb.AppendLine(headerText);
                tv.Text = sb.ToString();
                int numOfTest = 0;

                if(te3eTransSrvOptionCheckBox1.Checked == true)
                {
                    //MessageBox.ErrorQuery("NBI MATTER (MATTER_SRV_RC - ADD)", "IN PROGRESS. PRESS Ok TO CONTINUE.", "Ok");
                    sb.AppendLine("NBI MATTER (MATTER_SRV_RC - ADD) PROCESS IS RUNNING ...");
                    numOfTest++;
                    var csXml = GetXmlSample(TE3ETRANS.MATTER_ADD);
                    var results = tE3ETransactionClient.ExecuteProcess(csXml);

                    if (results.processExecutionResult == TE3EConnect.ProcessExecResult.Success)
                    {
                        sb.AppendLine("NBI MATTER (MATTER_SRV_RC - ADD) PROCESS RESULT: PASS");
                    }
                    else
                    {
                        sb.AppendLine("NBI MATTER (MATTER_SRV_RC - ADD) PROCESS RESULT: FAIL");
                        sb.AppendLine("SEE LOGS FOR MORE DETAILS ...");
                    }
                    sb.AppendLine("");
                    sb.AppendLine("---------------------BEGIN NBI MATTER (MATTER_SRV_RC - ADD) PROCESS OUTPUT LOGS----------------------");
                    sb.AppendLine(results.message);
                    sb.AppendLine("---------------------END NBI MATTER (MATTER_SRV_RC - ADD) PROCESS OUTPUT LOGS------------------------");
                    sb.AppendLine("");
                    sb.AppendLine("===========================================================================");
                    tv.Text = sb.ToString();

                }

                if (te3eTransSrvOptionCheckBox2.Checked == true)
                {
                    //MessageBox.ErrorQuery("PURCHASE REQUEST (POReqWF_CCC - ADD)", "IN PROGRESS. PRESS Ok TO CONTINUE.", "Ok");
                    sb.AppendLine("PURCHASE REQUEST (POREQWF_CCC - ADD) PROCESS IS RUNNING ...");
                    numOfTest++;
                    var csXml = GetXmlSample(TE3ETRANS.PURREQ_ADD);
                    var results = tE3ETransactionClient.ExecuteProcess(csXml);

                    if (results.processExecutionResult == TE3EConnect.ProcessExecResult.Success
                       || results.processExecutionResult == TE3EConnect.ProcessExecResult.Interface)
                    {
                        sb.AppendLine("PURCHASE REQUEST (POREQWF_CCC - ADD) PROCESS RESULT: PASS");
                    }
                    else
                    {
                        sb.AppendLine("PURCHASE REQUEST (POREQWF_CCC - ADD) PROCESS RESULT: FAIL");
                        sb.AppendLine("SEE LOGS FOR MORE DETAILS ...");
                    }
                    sb.AppendLine("");
                    sb.AppendLine("---------------------BEGIN PURCHASE REQUEST (POREQWF_CCC - ADD) PROCESS OUTPUT LOGS----------------------");
                    sb.AppendLine(results.message);
                    sb.AppendLine("---------------------END PURCHASE REQUEST (POREQWF_CCC - ADD) PROCESS OUTPUT LOGS------------------------");
                    sb.AppendLine("");
                    sb.AppendLine("===========================================================================");
                    tv.Text = sb.ToString();
                }

                if (te3eTransSrvOptionCheckBox3.Checked == true)
                {
                    //MessageBox.ErrorQuery("PURCHASE REQUEST (POReqWF_CCC - ADD)", "IN PROGRESS. PRESS Ok TO CONTINUE.", "Ok");
                    sb.AppendLine("TIMEKEEPER (TIMEKEEPER_SRV - ADD) PROCESS IS RUNNING ...");
                    numOfTest++;
                    var csXml = GetXmlSample(TE3ETRANS.TIMEKEEPER_ADD);
                    string tkprNum = $"T{DateTime.Now.ToString("yyyyMMdd_hhmmss")}";
                    csXml = csXml.Replace("@TkprNum", tkprNum)
                                 .Replace("@DisplayName", tkprNum)
                                 .Replace("@BillName", tkprNum)
                                 .Replace("@SortName", tkprNum.ToUpper());
                    var results = tE3ETransactionClient.ExecuteProcess(csXml);

                    if (results.processExecutionResult == TE3EConnect.ProcessExecResult.Success)
                    {
                        sb.AppendLine("TIMEKEEPER (TIMEKEEPER_SRV - ADD) PROCESS RESULT: PASS");
                    }
                    else
                    {
                        sb.AppendLine("TIMEKEEPER (TIMEKEEPER_SRV - ADD) PROCESS RESULT: FAIL");
                        sb.AppendLine("SEE LOGS FOR MORE DETAILS ...");
                    }
                    sb.AppendLine("");
                    sb.AppendLine("---------------------BEGIN TIMEKEEPER (TIMEKEEPER_SRV - ADD) PROCESS OUTPUT LOGS----------------------");
                    sb.AppendLine(results.message);
                    sb.AppendLine("---------------------END TIMEKEEPER (TIMEKEEPER_SRV - ADD) PROCESS OUTPUT LOGS------------------------");
                    sb.AppendLine("");
                    sb.AppendLine("===========================================================================");
                    tv.Text = sb.ToString();
                }

                if (te3eTransSrvOptionCheckBox4.Checked == true)
                {
                    //MessageBox.ErrorQuery("PURCHASE REQUEST (POReqWF_CCC - ADD)", "IN PROGRESS. PRESS Ok TO CONTINUE.", "Ok");
                    sb.AppendLine("USER (NXUSER_SRV - ADD) PROCESS IS RUNNING ...");
                    numOfTest++;
                    var csXml = GetXmlSample(TE3ETRANS.NXUSER_ADD);
                    var results = tE3ETransactionClient.ExecuteProcess(csXml);

                    if (results.processExecutionResult == TE3EConnect.ProcessExecResult.Success)
                    {
                        sb.AppendLine("USER (NXUSER_SRV - ADD) PROCESS RESULT: PASS");
                    }
                    else
                    {
                        sb.AppendLine("USER (NXUSER_SRV - ADD) PROCESS RESULT: FAIL");
                        sb.AppendLine("SEE LOGS FOR MORE DETAILS ...");
                    }
                    sb.AppendLine("");
                    sb.AppendLine("---------------------BEGIN USER (NXUSER_SRV - ADD) PROCESS OUTPUT LOGS----------------------");
                    sb.AppendLine(results.message);
                    sb.AppendLine("---------------------END USER (NXUSER_SRV - ADD) PROCESS OUTPUT LOGS------------------------");
                    sb.AppendLine("");
                    sb.AppendLine("===========================================================================");
                    tv.Text = sb.ToString();
                }
                if (numOfTest == 0)
                    MessageBox.ErrorQuery("NO TEST SELECTED", "PLEASE SELECT A TEST", "Ok");

                logger.Info(tv.Text);
            };

			// Add the views to the Window
			win.Add(environmentOptionLabel, environmentOptionComboBox, te3eTransSrvOptionLabel, te3eTransSrvOptionCheckBox1, te3eTransSrvOptionCheckBox2, te3eTransSrvOptionCheckBox3, te3eTransSrvOptionCheckBox4, tv, btnLogin);

			// Add both menu and win in a single call
			Application.Top.Add(menu, win);
            Application.Run();
            Application.Shutdown();
        }


        public static string GetXmlSample(TE3ETRANS tE3ETRANS)
        {
            string csXml = "";

            if(tE3ETRANS == TE3ETRANS.MATTER_ADD)
            {
                string strTemplate = "mattersrv_payload.xml";

                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"Samples/NBI/{strTemplate}")))
                {
                    csXml = objStreamReader.ReadToEnd();
                }
            }
            else if (tE3ETRANS == TE3ETRANS.PURREQ_ADD)
            {
                string strTemplate = "po_request_payload.xml";

                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"Samples/PO/{strTemplate}")))
                {
                    csXml = objStreamReader.ReadToEnd();
                }
            }
            else if (tE3ETRANS == TE3ETRANS.TIMEKEEPER_ADD)
            {
                string strTemplate = "timekeeper_payload.xml";

                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"Samples/Timekeeper/{strTemplate}")))
                {
                    csXml = objStreamReader.ReadToEnd();
                }
            }
            else if (tE3ETRANS == TE3ETRANS.NXUSER_ADD)
            {
                string strTemplate = "user_payload.xml";

                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"Samples/User/{strTemplate}")))
                {
                    csXml = objStreamReader.ReadToEnd();
                }
            }

            return csXml;
        }
    }

    public enum TE3ETRANS
    {
        MATTER_ADD,
        PURREQ_ADD,
        TIMEKEEPER_ADD,
        NXUSER_ADD

    }
}

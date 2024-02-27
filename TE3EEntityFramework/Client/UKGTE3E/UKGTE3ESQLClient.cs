using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Data.UKGTE3E;
using TE3EEntityFramework.Datasource.UKGTE3E.DataModel;
using TE3EEntityFramework.Extension;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client.UKGTE3E
{
    public class UKGTE3ESQLClient
    {
        private UKGTE3EAppSetting _appSettings;

        public UKGTE3ESQLClient(UKGTE3EAppSetting appSettings)
        {
            _appSettings = appSettings;
        }

        #region UKG te3e timekeeper
        public List<UKGTE3ETimekprInfo> GetUKGTE3ETimekeepers()
        {
            List<ukg3e_get_timekeeper_sp_Result> timekeepers = new List<ukg3e_get_timekeeper_sp_Result>();
            List<UKGTE3ETimekprInfo> uKGTE3ETimekprInfos = new List<UKGTE3ETimekprInfo>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.ukg3e_get_timekeeper_sp(_appSettings.AttemptsAllowed).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.ukg3e_get_timekeeper_sp(_appSettings.AttemptsAllowed).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.ukg3e_get_timekeeper_sp(_appSettings.AttemptsAllowed).ToList();
                }
            }


            timekeepers.GroupBy(x => x.Number).ToList().ForEach(x =>
            {
                UKGTE3ETimekprInfo uKGTE3ETimekprInfo = new UKGTE3ETimekprInfo();
                uKGTE3ETimekprInfo.ID = x.First().ID;
                uKGTE3ETimekprInfo.Number = x.First() != null ? x.First().Number : "0";
                uKGTE3ETimekprInfo.TkprIndex = x.First().TkprIndex != null ? (int)x.First().TkprIndex : 0;
                uKGTE3ETimekprInfo.UserName = x.First().UserName;
                uKGTE3ETimekprInfo.Email = x.First().Email;
                uKGTE3ETimekprInfo.AltNumber = x.First().AltNumber;
                uKGTE3ETimekprInfo.Entity = x.First().Entity;
                uKGTE3ETimekprInfo.EntityIndex = x.First().EntityIndex != null ? (int)x.First().EntityIndex : 0;
                uKGTE3ETimekprInfo.Entity_Type = x.First().Entity_Type;
                uKGTE3ETimekprInfo.FirstName = x.First().FirstName;
                uKGTE3ETimekprInfo.LastName = x.First().LastName;
                uKGTE3ETimekprInfo.MiddleName = x.First().MiddleName;
                uKGTE3ETimekprInfo.Display_Name = x.First().Display_Name;
                uKGTE3ETimekprInfo.Type = x.First().Type;
                uKGTE3ETimekprInfo.Payroll_Number = x.First().Payroll_Number;
                uKGTE3ETimekprInfo.HR_Number = x.First().HR_Number;
                uKGTE3ETimekprInfo.Bill_Name = x.First().Bill_Name;
                uKGTE3ETimekprInfo.Bill_Initial = x.First().Bill_Initial;
                uKGTE3ETimekprInfo.Status = x.First().Status;
                uKGTE3ETimekprInfo.Sort_Name = x.First().Sort_Name;
                uKGTE3ETimekprInfo.Timekeeper_Category = x.First().Timekeeper_Category;
                uKGTE3ETimekprInfo.Office = x.First().Office;
                uKGTE3ETimekprInfo.Department = x.First().Department;
                uKGTE3ETimekprInfo.Section = x.First().Section;

                if (x.First().Hire_Date != null)
                    uKGTE3ETimekprInfo.Hire_Date = (DateTime)x.First().Hire_Date;

                if(x.First().EffStart != null)
                    uKGTE3ETimekprInfo.EffStart = (DateTime)x.First().EffStart;

                if (x.First().CompDate != null)
                    uKGTE3ETimekprInfo.CompDate = (DateTime)x.First().CompDate;

                if (x.First().Termination_Date != null)
                    uKGTE3ETimekprInfo.Termination_Date = (DateTime)x.First().Termination_Date;

                uKGTE3ETimekprInfo.Title = x.First().Title;
                uKGTE3ETimekprInfo.Rate_Class = x.First().Rate_Class;
                uKGTE3ETimekprInfo.Work_Calender = x.First().Work_Calender;
                uKGTE3ETimekprInfo.Unit = x.First().Unit;
                uKGTE3ETimekprInfo.Supervising_timeKeeper = x.First().Supervising_timeKeeper;
                uKGTE3ETimekprInfo.Work_type = x.First().Work_type;
                uKGTE3ETimekprInfo.Billing_Corodinator = x.First().Billing_Corodinator;
                uKGTE3ETimekprInfo.Sitephone = x.First().Sitephone;
                uKGTE3ETimekprInfo.ImportedDate = x.First().ImportedDate != null ? (DateTime)x.First().ImportedDate : DateTime.MinValue;
                uKGTE3ETimekprInfo.SvcOperation = x.First().SvcOperation;
                uKGTE3ETimekprInfo.NumOfAttempt = x.First().NumOfAttempt != null ? (int)x.First().NumOfAttempt : 0;
                uKGTE3ETimekprInfo.LogInfo = x.First().LogInfo;

                if(x.First().LastChangeTimeStamp != null)
                    uKGTE3ETimekprInfo.LastChangeTimeStamp = (DateTime)x.First().LastChangeTimeStamp;

                uKGTE3ETimekprInfo.IsProcessed = x.First().IsProcessed != null ? (bool)x.First().IsProcessed : false;
                uKGTE3ETimekprInfo.ProcessedDate = x.First().ProcessedDate != null ? (DateTime)x.First().ProcessedDate : DateTime.MinValue;

                uKGTE3ETimekprInfo.TkprLicenseInfo = new List<TkprLicenseInfo>();
                x.ToList().ForEach(y =>
                {
                    if(!string.IsNullOrEmpty(y.LicenseType)
                    && !string.IsNullOrEmpty(y.LicCertificationNo)
                    && y.LicExpiration != null 
                    && !string.IsNullOrEmpty(y.LicState))
                    {

                        TkprLicenseInfo tkprLicenseInfo = new TkprLicenseInfo();
                        tkprLicenseInfo.LicenseType = y.LicenseType;
                        tkprLicenseInfo.LicCountry = y.LicCountry;
                        tkprLicenseInfo.LicCertificationNo = y.LicCertificationNo;
                        tkprLicenseInfo.LicExpiration = y.LicExpiration != null ? (DateTime)y.LicExpiration : DateTime.MinValue;
                        tkprLicenseInfo.LicState = y.LicState;

                        uKGTE3ETimekprInfo.TkprLicenseInfo.Add(tkprLicenseInfo);
                    }
                });

                uKGTE3ETimekprInfos.Add(uKGTE3ETimekprInfo);
            });

            return uKGTE3ETimekprInfos;
        }

        public void UpdateUKGTE3ETimekeeper(string tkprNumber, int numOfAttempt, string logInfo, bool isProcessed, DateTime processedDate)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_update_timekeeper_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_update_timekeeper_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_update_timekeeper_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
        }

        public void AddUKGTE3ETimekeeper(List<ukg3e_get_timekeeper_sp_Result> uKGTE3ETimekprs)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.ukg3e_add_timekeeper_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.ukg3e_add_timekeeper_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                        db.ukg3e_add_timekeeper_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
        }

        public void DeleteUKGTE3ETimekeeper(string tkprNumber)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_delete_timekeeper_sp(tkprNumber);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_delete_timekeeper_sp(tkprNumber);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ukg3e_delete_timekeeper_sp(tkprNumber);
                }
            }
        }

        public ukg3e_get_tkpr_by_num_sp_Result GetExistingTkpr(string tkprNumber, string displayName = "")
        {
            List<ukg3e_get_tkpr_by_num_sp_Result> existingTkpr = GetTkprByNum(tkprNumber);


            if (existingTkpr.Count() == 0)
            {
                if(!string.IsNullOrEmpty(displayName))
                {
                    var existingTkprByName = GetTkprByDisplayName(displayName);

                    if (existingTkprByName.Count() > 0)
                    {
                        existingTkpr = existingTkprByName.Select(x => new ukg3e_get_tkpr_by_num_sp_Result
                        {
                            BillInitial = x.BillInitial,
                            BillName = x.BillName,
                            DisplayName = x.DisplayName,
                            Entity = x.Entity,
                            Number = x.Number,
                            SortName = x.SortName,
                            TkprIndex = x.TkprIndex,
                            TkprStatus = x.TkprStatus
                        }).ToList();
                    }
                }
            }

            return existingTkpr.Count() > 0 ? existingTkpr.First() : new ukg3e_get_tkpr_by_num_sp_Result();
        }

        private List<ukg3e_get_tkpr_by_num_sp_Result> GetTkprByNum(string tkprNumber)
        {
            List<ukg3e_get_tkpr_by_num_sp_Result> ukg3ETkprs = new List<ukg3e_get_tkpr_by_num_sp_Result>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_num_sp(tkprNumber).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_num_sp(tkprNumber).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_num_sp(tkprNumber).ToList();
                }
            }

            return ukg3ETkprs;
        }

        private List<ukg3e_get_tkpr_by_displayname_sp_Result> GetTkprByDisplayName(string displayName)
        {
            List<ukg3e_get_tkpr_by_displayname_sp_Result> ukg3ETkprs = new List<ukg3e_get_tkpr_by_displayname_sp_Result>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_displayname_sp(displayName).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_displayname_sp(displayName).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3ETkprs = db.ukg3e_get_tkpr_by_displayname_sp(displayName).ToList();
                }
            }

            return ukg3ETkprs;
        }

        public List<ukg3e_get_entityperson_by_first_middle_last_name_sp_Result> GetEntityPersonByFMLName(string firstName, string middleName, string lastName)
        {
            List<ukg3e_get_entityperson_by_first_middle_last_name_sp_Result> ukg3EEntityPersons = new List<ukg3e_get_entityperson_by_first_middle_last_name_sp_Result>();

            string mName = string.IsNullOrEmpty(middleName) ? "" : middleName.Substring(0, 1);

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_by_first_middle_last_name_sp(firstName, mName, lastName).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_by_first_middle_last_name_sp(firstName, mName, lastName).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_by_first_middle_last_name_sp(firstName, mName, lastName).ToList();
                }
            }

            return ukg3EEntityPersons;
        }

        public List<ukg3e_get_entityperson_sp_Result> GetEntityPersonByName(string displayName)
        {
            List<ukg3e_get_entityperson_sp_Result> ukg3EEntityPersons = new List<ukg3e_get_entityperson_sp_Result>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_sp(displayName).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_sp(displayName).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3EEntityPersons = db.ukg3e_get_entityperson_sp(displayName).ToList();
                }
            }

            return ukg3EEntityPersons;
        }

        public List<TkprDateInfo> GetTkprDateMax(string tkprNumber)
        {
            List<TkprDateInfo> ukg3E_Get_Tkpr_Dates = new List<TkprDateInfo>();
            var idParam = new SqlParameter
            {
                ParameterName = "@tkprNumber",
                Value = tkprNumber
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.Database.SqlQuery<TkprDateInfo>("exec [ukg3e_get_tkpr_date_all_sp] @tkprNumber ", idParam).ToList<TkprDateInfo>();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.Database.SqlQuery<TkprDateInfo>("exec [ukg3e_get_tkpr_date_all_sp] @tkprNumber ", idParam).ToList<TkprDateInfo>();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.Database.SqlQuery<TkprDateInfo>("exec [ukg3e_get_tkpr_date_all_sp] @tkprNumber ", idParam).ToList<TkprDateInfo>();
                }
            }

            return ukg3E_Get_Tkpr_Dates;
        }

        public ukg3e_get_tkpr_date_sp_Result GetTkprDate(string tkprNumber, string tkprEffDate)
        {
            List<ukg3e_get_tkpr_date_sp_Result> ukg3E_Get_Tkpr_Dates = new List<ukg3e_get_tkpr_date_sp_Result>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.ukg3e_get_tkpr_date_sp(tkprNumber, tkprEffDate).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.ukg3e_get_tkpr_date_sp(tkprNumber, tkprEffDate).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Dates = db.ukg3e_get_tkpr_date_sp(tkprNumber, tkprEffDate).ToList();
                }
            }

            return ukg3E_Get_Tkpr_Dates.Count() > 0 ? ukg3E_Get_Tkpr_Dates.First() : null;
        }

        public List<ukg3e_get_tkpr_accreditation_sp_Result> GetTkprAccreditation(string certNumber, string licType, string state)
        {
            List<ukg3e_get_tkpr_accreditation_sp_Result> ukg3E_Get_Tkpr_Accreditations = null;

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Accreditations = db.ukg3e_get_tkpr_accreditation_sp(certNumber, licType, state).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Accreditations = db.ukg3e_get_tkpr_accreditation_sp(certNumber, licType, state).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Get_Tkpr_Accreditations = db.ukg3e_get_tkpr_accreditation_sp(certNumber, licType, state).ToList();
                }
            }

            return ukg3E_Get_Tkpr_Accreditations;
        }

        public List<EntityProcessItem> GetPersonEntityProcessItems(string server, string dbInstance, string personEntityPId)
        {
            List<EntityProcessItem> entityProcessItems = new List<EntityProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/ukgte3e/sqlscripts/GetPersonEntityProcessItem.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@personProcessItemId", personEntityPId);

                if (_appSettings.TE3EEnv == TE3EEnv.DEV)
                {
                    using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                    {
                        db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                        entityProcessItems = db.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                    }
                }
                else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
                {
                    using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                    {
                        db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                        entityProcessItems = db.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                    }
                }
                else
                {
                    using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                    {
                        db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                        entityProcessItems = db.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                    }
                }
            }

            return entityProcessItems;
        }

        public List<ukg3e_lookup_code_sp_Result> GetLookupCode(string desc, UKGTE3ELookupTypes uKGTE3ELookupType)
        {
            List<ukg3e_lookup_code_sp_Result> ukg3E_Lookup_Codes = null;

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Lookup_Codes = db.ukg3e_lookup_code_sp(desc, TE3EEntityExt.GetEnumDescription(uKGTE3ELookupType)).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Lookup_Codes = db.ukg3e_lookup_code_sp(desc, TE3EEntityExt.GetEnumDescription(uKGTE3ELookupType)).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukg3E_Lookup_Codes = db.ukg3e_lookup_code_sp(desc, TE3EEntityExt.GetEnumDescription(uKGTE3ELookupType)).ToList();
                }
            }

            return ukg3E_Lookup_Codes;
        }

        public void AddTransactionLog(UKG_TE_3E_TRANSACTION_LOGS uKG_TE_3E_TRANSACTION)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
        }

        #endregion UKG te3e timekeeper

        #region OneLogin te3e user
        public List<NxUserInfo> GetOneLoginTE3EUsers()
        {
            List<ukg3e_get_timekeeper_sp_Result> timekeepers = new List<ukg3e_get_timekeeper_sp_Result>();
            List<NxUserInfo> nxUserInfos = new List<NxUserInfo>();
           
            var idParam = new SqlParameter
            {
                ParameterName = "@numOfAttempt",
                Value = _appSettings.AttemptsAllowed
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.Database.SqlQuery<ukg3e_get_timekeeper_sp_Result>("exec [onelogin3e_get_user_sp] @numOfAttempt ", idParam).ToList<ukg3e_get_timekeeper_sp_Result>();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.Database.SqlQuery<ukg3e_get_timekeeper_sp_Result>("exec [onelogin3e_get_user_sp] @numOfAttempt ", idParam).ToList<ukg3e_get_timekeeper_sp_Result>();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    timekeepers = db.Database.SqlQuery<ukg3e_get_timekeeper_sp_Result>("exec [onelogin3e_get_user_sp] @numOfAttempt ", idParam).ToList<ukg3e_get_timekeeper_sp_Result>();
                }
            }

            timekeepers.GroupBy(x => x.Number).ToList().ForEach(x =>
            {
                NxUserInfo nxUserInfo = new NxUserInfo();

                #region timekeeper
                nxUserInfo.UKGTE3ETimekpr = new UKGTE3ETimekprInfo();
                nxUserInfo.UKGTE3ETimekpr.ID = x.First().ID;
                nxUserInfo.UKGTE3ETimekpr.Number = x.First() != null ? x.First().Number : "0";
                nxUserInfo.UKGTE3ETimekpr.TkprIndex = x.First().TkprIndex != null ? (int)x.First().TkprIndex : 0;
                nxUserInfo.UKGTE3ETimekpr.UserName = x.First().UserName;
                nxUserInfo.UKGTE3ETimekpr.Email = x.First().Email;
                nxUserInfo.UKGTE3ETimekpr.AltNumber = x.First().AltNumber;
                nxUserInfo.UKGTE3ETimekpr.Entity = x.First().Entity;
                nxUserInfo.UKGTE3ETimekpr.EntityIndex = x.First().EntityIndex != null ? (int)x.First().EntityIndex : 0;
                nxUserInfo.UKGTE3ETimekpr.Entity_Type = x.First().Entity_Type;
                nxUserInfo.UKGTE3ETimekpr.FirstName = x.First().FirstName;
                nxUserInfo.UKGTE3ETimekpr.LastName = x.First().LastName;
                nxUserInfo.UKGTE3ETimekpr.MiddleName = x.First().MiddleName;
                nxUserInfo.UKGTE3ETimekpr.Display_Name = x.First().Display_Name;
                nxUserInfo.UKGTE3ETimekpr.Type = x.First().Type;
                nxUserInfo.UKGTE3ETimekpr.Payroll_Number = x.First().Payroll_Number;
                nxUserInfo.UKGTE3ETimekpr.HR_Number = x.First().HR_Number;
                nxUserInfo.UKGTE3ETimekpr.Bill_Name = x.First().Bill_Name;
                nxUserInfo.UKGTE3ETimekpr.Bill_Initial = x.First().Bill_Initial;
                nxUserInfo.UKGTE3ETimekpr.Status = x.First().Status;
                nxUserInfo.UKGTE3ETimekpr.Sort_Name = x.First().Sort_Name;
                nxUserInfo.UKGTE3ETimekpr.Timekeeper_Category = x.First().Timekeeper_Category;
                nxUserInfo.UKGTE3ETimekpr.Office = x.First().Office;
                nxUserInfo.UKGTE3ETimekpr.Department = x.First().Department;
                nxUserInfo.UKGTE3ETimekpr.Section = x.First().Section;

                if (x.First().Hire_Date != null)
                    nxUserInfo.UKGTE3ETimekpr.Hire_Date = (DateTime)x.First().Hire_Date;

                if (x.First().EffStart != null)
                    nxUserInfo.UKGTE3ETimekpr.EffStart = (DateTime)x.First().EffStart;

                if (x.First().CompDate != null)
                    nxUserInfo.UKGTE3ETimekpr.CompDate = (DateTime)x.First().CompDate;

                if (x.First().Termination_Date != null)
                    nxUserInfo.UKGTE3ETimekpr.Termination_Date = (DateTime)x.First().Termination_Date;

                nxUserInfo.UKGTE3ETimekpr.Title = x.First().Title;
                nxUserInfo.UKGTE3ETimekpr.Rate_Class = x.First().Rate_Class;
                nxUserInfo.UKGTE3ETimekpr.Work_Calender = x.First().Work_Calender;
                nxUserInfo.UKGTE3ETimekpr.Unit = x.First().Unit;
                nxUserInfo.UKGTE3ETimekpr.Supervising_timeKeeper = x.First().Supervising_timeKeeper;
                nxUserInfo.UKGTE3ETimekpr.Work_type = x.First().Work_type;
                nxUserInfo.UKGTE3ETimekpr.Billing_Corodinator = x.First().Billing_Corodinator;
                nxUserInfo.UKGTE3ETimekpr.Sitephone = x.First().Sitephone;
                nxUserInfo.UKGTE3ETimekpr.ImportedDate = x.First().ImportedDate != null ? (DateTime)x.First().ImportedDate : DateTime.MinValue;
                nxUserInfo.UKGTE3ETimekpr.SvcOperation = x.First().SvcOperation;
                nxUserInfo.UKGTE3ETimekpr.NumOfAttempt = x.First().NumOfAttempt != null ? (int)x.First().NumOfAttempt : 0;
                nxUserInfo.UKGTE3ETimekpr.LogInfo = x.First().LogInfo;

                if (x.First().LastChangeTimeStamp != null)
                    nxUserInfo.UKGTE3ETimekpr.LastChangeTimeStamp = (DateTime)x.First().LastChangeTimeStamp;

                nxUserInfo.UKGTE3ETimekpr.IsProcessed = x.First().IsProcessed != null ? (bool)x.First().IsProcessed : false;
                nxUserInfo.UKGTE3ETimekpr.ProcessedDate = x.First().ProcessedDate != null ? (DateTime)x.First().ProcessedDate : DateTime.MinValue;

                nxUserInfo.UKGTE3ETimekpr.TkprLicenseInfo = new List<TkprLicenseInfo>();
                x.ToList().ForEach(y =>
                {
                    if (!string.IsNullOrEmpty(y.LicenseType)
                    && !string.IsNullOrEmpty(y.LicCertificationNo)
                    && y.LicExpiration != null
                    && !string.IsNullOrEmpty(y.LicState))
                    {

                        TkprLicenseInfo tkprLicenseInfo = new TkprLicenseInfo();
                        tkprLicenseInfo.LicenseType = y.LicenseType;
                        tkprLicenseInfo.LicCountry = y.LicCountry;
                        tkprLicenseInfo.LicCertificationNo = y.LicCertificationNo;
                        tkprLicenseInfo.LicExpiration = y.LicExpiration != null ? (DateTime)y.LicExpiration : DateTime.MinValue;
                        tkprLicenseInfo.LicState = y.LicState;

                        nxUserInfo.UKGTE3ETimekpr.TkprLicenseInfo.Add(tkprLicenseInfo);
                    }
                });

                #endregion timekeeper

                #region nxuser

                nxUserInfo.UKGTE3EUser = new UKGTE3EUserInfo();
                nxUserInfo.UKGTE3EUser.FirstName = x.First().FirstName;
                nxUserInfo.UKGTE3EUser.LastName = x.First().LastName;
                nxUserInfo.UKGTE3EUser.UserName = x.First().UserName;
                //nxUserInfo.UKGTE3EUser.TimeZone= x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.Language= x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.Dashboard= x.First().Sitephone;
                nxUserInfo.UKGTE3EUser.EmailAddr = x.First().Email;
                nxUserInfo.UKGTE3EUser.NetworkAlias = x.First().UserName;
                //nxUserInfo.UKGTE3EUser.OptionsRole = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.DefaultUnit = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.Office = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.CanSwitchOperatingUnit = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.DataRole = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.IsAllowTimeEntry = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.CanProxy = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.CanEditDashboard = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.WinTimeZone = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.CanEditGlobalModel = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.CanEditCompanyHeader = x.First().Sitephone;
                //nxUserInfo.UKGTE3EUser.TimekeeperIndex = x.First().Sitephone;
        
                #endregion nxuser

                nxUserInfos.Add(nxUserInfo);
            });

            return nxUserInfos;
        }

        public void UpdateOneLoginTE3EUser(string tkprNumber, int numOfAttempt, string logInfo, bool isProcessed, DateTime processedDate)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_update_user_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_update_user_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_update_user_sp(tkprNumber, numOfAttempt, logInfo, isProcessed, processedDate);
                }
            }
        }

        public void AddOneLoginTE3EUser(List<ukg3e_get_timekeeper_sp_Result> uKGTE3ETimekprs)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.onelogin3e_add_user_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.onelogin3e_add_user_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {

                    uKGTE3ETimekprs.ForEach(uKGTE3ETimekpr =>
                    {
                        db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                        db.onelogin3e_add_user_sp(uKGTE3ETimekpr.Number,
                                                uKGTE3ETimekpr.TkprIndex,
                                                uKGTE3ETimekpr.UserName,
                                                uKGTE3ETimekpr.Email,
                                                uKGTE3ETimekpr.AltNumber,
                                                uKGTE3ETimekpr.Entity,
                                                uKGTE3ETimekpr.EntityIndex,
                                                uKGTE3ETimekpr.Entity_Type,
                                                uKGTE3ETimekpr.FirstName,
                                                uKGTE3ETimekpr.LastName,
                                                uKGTE3ETimekpr.MiddleName,
                                                uKGTE3ETimekpr.Display_Name,
                                                uKGTE3ETimekpr.Type,
                                                uKGTE3ETimekpr.Payroll_Number,
                                                uKGTE3ETimekpr.HR_Number,
                                                uKGTE3ETimekpr.Bill_Name,
                                                uKGTE3ETimekpr.Bill_Initial,
                                                uKGTE3ETimekpr.Status,
                                                uKGTE3ETimekpr.Sort_Name,
                                                uKGTE3ETimekpr.CompDate,
                                                uKGTE3ETimekpr.Timekeeper_Category,
                                                uKGTE3ETimekpr.EffStart,
                                                uKGTE3ETimekpr.Office,
                                                uKGTE3ETimekpr.Department,
                                                uKGTE3ETimekpr.Section,
                                                uKGTE3ETimekpr.Hire_Date,
                                                uKGTE3ETimekpr.Termination_Date,
                                                uKGTE3ETimekpr.Title,
                                                uKGTE3ETimekpr.Rate_Class,
                                                uKGTE3ETimekpr.Work_Calender,
                                                uKGTE3ETimekpr.Unit,
                                                uKGTE3ETimekpr.Supervising_timeKeeper,
                                                uKGTE3ETimekpr.Work_type,
                                                uKGTE3ETimekpr.Billing_Corodinator,
                                                uKGTE3ETimekpr.Sitephone,
                                                uKGTE3ETimekpr.LicenseType,
                                                uKGTE3ETimekpr.LicCountry,
                                                uKGTE3ETimekpr.LicState,
                                                uKGTE3ETimekpr.LicExpiration,
                                                uKGTE3ETimekpr.LicCertificationNo,
                                                uKGTE3ETimekpr.LastChangeTimeStamp,
                                                uKGTE3ETimekpr.ImportedDate,
                                                uKGTE3ETimekpr.SvcOperation,
                                                uKGTE3ETimekpr.NumOfAttempt,
                                                uKGTE3ETimekpr.LogInfo,
                                                uKGTE3ETimekpr.IsProcessed,
                                                uKGTE3ETimekpr.ProcessedDate);
                    });

                }
            }
        }

        public void DeleteOneLoginTE3EUser(string tkprNumber)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_delete_user_sp(tkprNumber);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_delete_user_sp(tkprNumber);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.onelogin3e_delete_user_sp(tkprNumber);
                }
            }
        }

        public UKGTE3EUserInfo GetExistingTE3EUser(string networkAlias, string email)
        {
            var nxUser = GetOneLoginTE3EUserByNetworkId(networkAlias);

            if (nxUser == null)
                nxUser = GetOneLoginTE3EUserByEmail(email);

            return nxUser;
        }

        public UKGTE3EUserInfo GetOneLoginTE3EUserByNetworkId(string networkAlias)
        {
            List<UKGTE3EUserInfo> nxUsers = new List<UKGTE3EUserInfo>();

            var idParam = new SqlParameter
            {
                ParameterName = "@userName",
                Value = networkAlias
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_networkid_sp] @userName ", idParam).ToList<UKGTE3EUserInfo>();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_networkid_sp] @userName ", idParam).ToList<UKGTE3EUserInfo>();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_networkid_sp] @userName ", idParam).ToList<UKGTE3EUserInfo>();
                }
            }

            return nxUsers.Count() > 0 ? nxUsers.First() : null;
        }

        public UKGTE3EUserInfo GetOneLoginTE3EUserByEmail(string email)
        {
            List<UKGTE3EUserInfo> nxUsers = new List<UKGTE3EUserInfo>();

            var idParam = new SqlParameter
            {
                ParameterName = "@email",
                Value = email
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    //nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
                    nxUsers = db.onelogin3e_get_user_by_email_sp(email).Select(x => new UKGTE3EUserInfo()
                    {
                        BaseUserName = x.BaseUserName,
                        CanEditDashboard = x.CanEditDashboard ?? byte.MinValue,
                        CanProxy = x.CanProxy ?? byte.MinValue,
                        CanSwitchOperatingUnit = x.CanSwitchOperatingUnit,
                        Dashboard = x.Dashboard ?? Guid.Empty,
                        DataRole = x.DataRole,
                        DefaultUnit = x.DefaultUnit,
                        Department_CCC = x.Department_CCC,
                        EmailAddr = x.EmailAddr,
                        Entity = x.Entity.ToString(),
                        Language = x.Language ?? Guid.Empty,
                        NetworkAlias = x.NetworkAlias,
                        NxFWKUserID = x.NxFWKUserID,
                        Office = x.Office,
                        Supervisor_CCC = x.Supervisor_CCC ?? Guid.Empty,
                        TimeZone = x.TimeZone,
                        WinTimeZone = x.WinTimeZone ?? Guid.Empty
                    }).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    //nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
                    //ToDo: Please commented only in case we have updated .edmx file for [onelogin3e_get_user_by_email_sp]
                    nxUsers = db.onelogin3e_get_user_by_email_sp(email).Select(x => new UKGTE3EUserInfo()
                    {
                        BaseUserName = x.BaseUserName,
                        CanEditDashboard = x.CanEditDashboard ?? byte.MinValue,
                        CanProxy = x.CanProxy ?? byte.MinValue,
                        CanSwitchOperatingUnit = x.CanSwitchOperatingUnit,
                        Dashboard = x.Dashboard ?? Guid.Empty,
                        DataRole = x.DataRole,
                        DefaultUnit = x.DefaultUnit,
                        Department_CCC = x.Department_CCC,
                        EmailAddr = x.EmailAddr,
                        Entity = x.Entity.ToString(),
                        Language = x.Language ?? Guid.Empty,
                        NetworkAlias = x.NetworkAlias,
                        NxFWKUserID = x.NxFWKUserID,
                        Office = x.Office,
                        Supervisor_CCC = x.Supervisor_CCC ?? Guid.Empty,
                        TimeZone = x.TimeZone,
                        WinTimeZone = x.WinTimeZone ?? Guid.Empty
                    }).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    //nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
                    //ToDo: Please commented only in case we have updated .edmx file for [onelogin3e_get_user_by_email_sp]
                    nxUsers = db.onelogin3e_get_user_by_email_sp(email).Select(x => new UKGTE3EUserInfo()
                    {
                        BaseUserName = x.BaseUserName,
                        CanEditDashboard = x.CanEditDashboard ?? byte.MinValue,
                        CanProxy = x.CanProxy ?? byte.MinValue,
                        CanSwitchOperatingUnit = x.CanSwitchOperatingUnit,
                        Dashboard = x.Dashboard ?? Guid.Empty,
                        DataRole = x.DataRole,
                        DefaultUnit = x.DefaultUnit,
                        Department_CCC = x.Department_CCC,
                        EmailAddr = x.EmailAddr,
                        Entity = x.Entity.ToString(),
                        Language = x.Language ?? Guid.Empty,
                        NetworkAlias = x.NetworkAlias,
                        NxFWKUserID = x.NxFWKUserID,
                        Office = x.Office,
                        Supervisor_CCC = x.Supervisor_CCC ?? Guid.Empty,
                        TimeZone = x.TimeZone,
                        WinTimeZone = x.WinTimeZone ?? Guid.Empty
                    }).ToList();
                }
            }

            return nxUsers.Count() > 0 ? nxUsers.First() : null;
        }

        public void AddNxUserTransactionLog(ONELOGIN_TE_3E_TRANSACTION_LOGS uKG_TE_3E_TRANSACTION)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ONELOGIN_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ONELOGIN_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.ONELOGIN_TE_3E_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
        }

        #endregion OneLogin te3e user

        #region UKG te3e purchase order
        public List<UKG_TE_3E_PO> GetExisitingUKGTE3EPOs(string bundleWithSubmissionId)
        {
            List<UKG_TE_3E_PO> uKG_TE_3E_POs = new List<UKG_TE_3E_PO>();

            var idParam = new SqlParameter
            {
                ParameterName = "@bundleWithSubmissionId",
                Value = bundleWithSubmissionId
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_existing_po_sp] @bundleWithSubmissionId ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_existing_po_sp] @bundleWithSubmissionId ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_existing_po_sp] @bundleWithSubmissionId ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }

            return uKG_TE_3E_POs;
        }

        public List<UKG_TE_3E_PO> GetUKGTE3EPOs()
        {
            List<UKG_TE_3E_PO> uKG_TE_3E_POs = new List<UKG_TE_3E_PO>();

            var idParam = new SqlParameter
            {
                ParameterName = "@numOfAttempt",
                Value = _appSettings.AttemptsAllowed
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_po_sp] @numOfAttempt ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_po_sp] @numOfAttempt ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKG_TE_3E_POs = db.Database.SqlQuery<UKG_TE_3E_PO>("exec [ukg3e_get_po_sp] @numOfAttempt ", idParam).ToList<UKG_TE_3E_PO>();
                }
            }

            return uKG_TE_3E_POs;
        }

        public void UpdateUKGTE3EPO(UKG_TE_3E_PO po)
        {

            var idParams = new[]{
                                    new SqlParameter { ParameterName = "@Id", Value = po.ID },
                                    new SqlParameter { ParameterName = "@NumOfAttempt", Value = (po.NumOfAttempt + 1) },
                                    new SqlParameter { ParameterName = "@LogInfo", Value = po.LogInfo },
                                    new SqlParameter { ParameterName = "@IsProcessed", Value = po.IsProcessed },
                                    new SqlParameter { ParameterName = "@ProcessedDate", Value = DateTime.Now },
                        };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    db.Database.ExecuteSqlCommand(@"exec [ukg3e_update_po_sp] 
                                                                @Id, 
                                                                @NumOfAttempt,
                                                                @logInfo,
                                                                @IsProcessed,
                                                                @ProcessedDate", idParams);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    db.Database.ExecuteSqlCommand(@"exec [ukg3e_update_po_sp] 
                                                                @Id, 
                                                                @NumOfAttempt,
                                                                @logInfo,
                                                                @IsProcessed,
                                                                @ProcessedDate", idParams);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    db.Database.ExecuteSqlCommand(@"exec [ukg3e_update_po_sp] 
                                                                @Id, 
                                                                @NumOfAttempt,
                                                                @logInfo,
                                                                @IsProcessed,
                                                                @ProcessedDate", idParams);
                }
            }
        }

        public void AddUKGTE3EPO(List<UKG_TE_3E_PO> uKG_TE_3E_POs)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    
                    uKG_TE_3E_POs.ForEach(po =>
                    {
                        var idParams = new[]{
                                    new SqlParameter { ParameterName = "@Supplier", Value = po.Supplier },
                                    new SqlParameter { ParameterName = "@ShipSite", Value = po.ShipSite },
                                    new SqlParameter { ParameterName = "@ShipInstructions", Value = po.ShipInstructions },
                                    new SqlParameter { ParameterName = "@Comments", Value = po.Comments },
                                    new SqlParameter { ParameterName = "@NxUser", Value = po.NxUser },
                                    new SqlParameter { ParameterName = "@EmailAddress", Value = po.EmailAddress },
                                    new SqlParameter { ParameterName = "@ReqDate", Value = po.ReqDate },
                                    new SqlParameter { ParameterName = "@StartDate", Value = po.StartDate },
                                    new SqlParameter { ParameterName = "@ProductBundle_CCC", Value = po.ProductBundle_CCC },
                                    new SqlParameter { ParameterName = "@ImportedDate", Value = DateTime.Now },
                                    new SqlParameter { ParameterName = "@SvcOperation", Value = "Add" },
                                    new SqlParameter { ParameterName = "@NumOfAttempt", Value = 0 }
                        };

                        db.Database.ExecuteSqlCommand(@"exec [ukg3e_add_po_sp] @Supplier, 
                                                                @ShipSite, 
                                                                @ShipInstructions, 
                                                                @Comments, 
                                                                @NxUser,
                                                                @EmailAddress,
                                                                @ReqDate,
                                                                @StartDate,
                                                                @ProductBundle_CCC,
                                                                @ImportedDate,
                                                                @SvcOperation,
                                                                @NumOfAttempt", idParams);

                       
                    });

                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKG_TE_3E_POs.ForEach(po =>
                    {
                        var idParams = new[]{
                                    new SqlParameter { ParameterName = "@Supplier", Value = po.Supplier },
                                    new SqlParameter { ParameterName = "@ShipSite", Value = po.ShipSite },
                                    new SqlParameter { ParameterName = "@ShipInstructions", Value = po.ShipInstructions },
                                    new SqlParameter { ParameterName = "@Comments", Value = po.Comments },
                                    new SqlParameter { ParameterName = "@NxUser", Value = po.NxUser },
                                    new SqlParameter { ParameterName = "@EmailAddress", Value = po.EmailAddress },
                                    new SqlParameter { ParameterName = "@ReqDate", Value = po.ReqDate },
                                    new SqlParameter { ParameterName = "@StartDate", Value = po.StartDate },
                                    new SqlParameter { ParameterName = "@ProductBundle_CCC", Value = po.ProductBundle_CCC },
                                    new SqlParameter { ParameterName = "@ImportedDate", Value = DateTime.Now },
                                    new SqlParameter { ParameterName = "@SvcOperation", Value = "Add" },
                                    new SqlParameter { ParameterName = "@NumOfAttempt", Value = 0 }
                        };

                        db.Database.ExecuteSqlCommand(@"exec [ukg3e_add_po_sp] @Supplier, 
                                                                @ShipSite, 
                                                                @ShipInstructions, 
                                                                @Comments, 
                                                                @NxUser, 
                                                                @EmailAddress,
                                                                @ReqDate,
                                                                @StartDate,
                                                                @ProductBundle_CCC,
                                                                @ImportedDate,
                                                                @SvcOperation,
                                                                @NumOfAttempt", idParams);


                    });

                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    uKG_TE_3E_POs.ForEach(po =>
                    {
                        var idParams = new[]{
                                    new SqlParameter { ParameterName = "@Supplier", Value = po.Supplier },
                                    new SqlParameter { ParameterName = "@ShipSite", Value = po.ShipSite },
                                    new SqlParameter { ParameterName = "@ShipInstructions", Value = po.ShipInstructions },
                                    new SqlParameter { ParameterName = "@Comments", Value = po.Comments },
                                    new SqlParameter { ParameterName = "@NxUser", Value = po.NxUser },
                                    new SqlParameter { ParameterName = "@EmailAddress", Value = po.EmailAddress },
                                    new SqlParameter { ParameterName = "@ReqDate", Value = po.ReqDate },
                                    new SqlParameter { ParameterName = "@StartDate", Value = po.StartDate },
                                    new SqlParameter { ParameterName = "@ProductBundle_CCC", Value = po.ProductBundle_CCC },
                                    new SqlParameter { ParameterName = "@ImportedDate", Value = DateTime.Now },
                                    new SqlParameter { ParameterName = "@SvcOperation", Value = "Add" },
                                    new SqlParameter { ParameterName = "@NumOfAttempt", Value = 0 }
                        };

                        db.Database.ExecuteSqlCommand(@"exec [ukg3e_add_po_sp] @Supplier, 
                                                                @ShipSite, 
                                                                @ShipInstructions, 
                                                                @Comments, 
                                                                @NxUser, 
                                                                @EmailAddress,
                                                                @ReqDate,
                                                                @StartDate,
                                                                @ProductBundle_CCC,
                                                                @ImportedDate,
                                                                @SvcOperation,
                                                                @NumOfAttempt", idParams);


                    });
                }
            }
        }

        public void DeleteUKGTE3EPO(string iD)
        {
            var idParam = new SqlParameter
            {
                ParameterName = "@Id",
                Value = Convert.ToInt32(iD)
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.Database.ExecuteSqlCommand("exec [ukg3e_delete_po_sp] @Id ", idParam);
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.Database.ExecuteSqlCommand("exec [ukg3e_delete_po_sp] @Id ", idParam);
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.Database.ExecuteSqlCommand("exec [ukg3e_delete_po_sp] @Id ", idParam);
                }
            }
        }

        public List<UKGTE3EPOProductsBundleInfo> GetUKGTE3EPOProductsBundle(string bundleCode)
        {
            List<UKGTE3EPOProductsBundleInfo> uKGTE3EPOProductsBundleInfos = new List<UKGTE3EPOProductsBundleInfo>();

            var idParam = new SqlParameter
            {
                ParameterName = "@bundleCode",
                Value = bundleCode
            };

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKGTE3EPOProductsBundleInfos = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_bundle_code_sp] @bundleCode ", idParam).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKGTE3EPOProductsBundleInfos = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_bundle_code_sp] @bundleCode ", idParam).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    uKGTE3EPOProductsBundleInfos = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_bundle_code_sp] @bundleCode ", idParam).ToList();
                }
            }

            return uKGTE3EPOProductsBundleInfos;
        }

        public UKGTE3EPOProductsBundleInfo GetUKGTE3EPOProductInfo(string productCode, string category)
        {
            UKGTE3EPOProductsBundleInfo uKGTE3EPOProductsBundleInfo = new UKGTE3EPOProductsBundleInfo();

            var idParams = new[]{
                                    new SqlParameter { ParameterName = "@productCode", Value = productCode },
                                    new SqlParameter { ParameterName = "@category", Value = category }
                        };


            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_product_code_sp] @productCode, @category ", idParams).ToList();
                    uKGTE3EPOProductsBundleInfo = results.Count() > 0 ? results.First() : null;
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_product_code_sp] @productCode, @category ", idParams).ToList();
                    uKGTE3EPOProductsBundleInfo = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.Database.SqlQuery<UKGTE3EPOProductsBundleInfo>("exec [ukg3e_get_products_by_product_code_sp] @productCode, @category ", idParams).ToList();
                    uKGTE3EPOProductsBundleInfo = results.Count() > 0 ? results.First() : null;
                }
            }

            return uKGTE3EPOProductsBundleInfo;
        }

        //public UKGTE3EUserInfo GetExistingTE3EUser(string networkAlias, string email)
        //{
        //    var nxUser = GetOneLoginTE3EUserByNetworkId(networkAlias);

        //    if (nxUser == null)
        //        nxUser = GetOneLoginTE3EUserByEmail(email);

        //    return nxUser;
        //}

        //public UKGTE3EUserInfo GetUKGTE3EPOByEmail(string email)
        //{
        //    List<UKGTE3EUserInfo> nxUsers = new List<UKGTE3EUserInfo>();

        //    var idParam = new SqlParameter
        //    {
        //        ParameterName = "@email",
        //        Value = email
        //    };

        //    if (_appSettings.TE3EEnv == TE3EEnv.DEV)
        //    {
        //        using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
        //        {
        //            db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
        //            nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
        //        }
        //    }
        //    else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
        //    {
        //        using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
        //        {
        //            db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
        //            nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
        //        }
        //    }
        //    else
        //    {
        //        using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
        //        {
        //            db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
        //            nxUsers = db.Database.SqlQuery<UKGTE3EUserInfo>("exec [onelogin3e_get_user_by_email_sp] @email ", idParam).ToList<UKGTE3EUserInfo>();
        //        }
        //    }

        //    return nxUsers.Count() > 0 ? nxUsers.First() : null;
        //}
        public REQUISITION_TE_3E_PO_REF GetRequisitionById(string submissionId)
        {
            REQUISITION_TE_3E_PO_REF requisition = null;
            int submissionID = Convert.ToInt32(submissionId);

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.REQUISITION_TE_3E_PO_REF.Where(r => r.ID == submissionID);
                    requisition = results.Count() > 0 ? results.First() : null;
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.REQUISITION_TE_3E_PO_REF.Where(r => r.ID == submissionID);
                    requisition = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var results = db.REQUISITION_TE_3E_PO_REF.Where(r => r.ID == submissionID);
                    requisition = results.Count() > 0 ? results.First() : null;
                }
            }

            return requisition;
        }

        public void AddPOTransactionLog(UKG_TE_3E_PO_TRANSACTION_LOGS uKG_TE_3E_TRANSACTION)
        {
            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_PO_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_PO_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.UKG_TE_3E_PO_TRANSACTION_LOGS.Add(uKG_TE_3E_TRANSACTION);
                    db.SaveChanges();
                }
            }

        }
        #endregion UKG te3e purchase order

        #region new code: UKG te3e user role/dashboard mappings 
        public List<string> GetRolesByBillingTitle(string billingTitle)
        {
            List<string> ukgRoleMappings = new List<string>();

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgRoleMappings = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).Select(x => x.RoleId.ToString()).ToList();
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgRoleMappings = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).Select(x => x.RoleId.ToString()).ToList();
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgRoleMappings = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).Select(x => x.RoleId.ToString()).ToList();
                }
            }

            return ukgRoleMappings;
        }

        public Guid? GetDashboardByBillingTitle(string billingTitle)
        {
            Guid? ukgDashboard = Guid.Empty;

            if (_appSettings.TE3EEnv == TE3EEnv.DEV)
            {
                using (UKGTE3E_DEV01Entities db = new UKGTE3E_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgDashboard = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).FirstOrDefault()?.DashboardId;
                }
            }
            else if (_appSettings.TE3EEnv == TE3EEnv.UAT)
            {
                using (UKGTE3E_UAT01Entities db = new UKGTE3E_UAT01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgDashboard = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).FirstOrDefault()?.DashboardId;
                }
            }
            else
            {
                using (UKGTE3E_PROD01Entities db = new UKGTE3E_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    ukgDashboard = db.ukg3e_get_dashboard_roles_by_billingtitle_sp(billingTitle).FirstOrDefault()?.DashboardId;
                }
            }

            return ukgDashboard;
        }

        #endregion
    }
}
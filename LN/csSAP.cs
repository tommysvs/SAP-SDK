using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using BE;

namespace LN
{
    public class csSAP
    {
        public static SAPbobsCOM.Company oCompany;
        public static int iRet = 0;
        public static int iErrCod = 0;
        public static string sErrMsg = "";

        public bool ConectarSAP(csCompany objCompany)
        {
            try
            {
                if(oCompany == null || oCompany.Connected)
                {
                    oCompany = new Company();
                    oCompany.Server = objCompany.ServerBD;
                    oCompany.DbUserName = objCompany.UserBD;
                    oCompany.DbPassword = objCompany.PwBD;
                    oCompany.CompanyDB = objCompany.NameBD;
                    if(objCompany.ServerLic != "") 
                        oCompany.LicenseServer = objCompany.ServerLic;
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PwSAP;

                    switch(objCompany.ServerType)
                    {
                        case 0:
                            oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                            break;
                        case 1:
                            oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2016;
                            break;
                    }

                    oCompany.language = BoSuppLangs.ln_Spanish_La;

                    iRet = oCompany.Connect();

                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DesconectarSAP(csCompany objCompany)
        {
            try
            {
                if(oCompany != null && oCompany.Connected)
                {
                    oCompany.Disconnect();
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddItems(ref csOITM objOITM)
        {
            try
            {
                SAPbobsCOM.Items oItems = oCompany.GetBusinessObject(BoObjectTypes.oItems);

                if (oItems.GetByKey(objOITM.ItemCode))
                {
                    #region Actualizar

                    oItems.Series = objOITM.Series;
                    //oItems.ItemCode = objOITM.ItemCode;
                    oItems.ItemName = objOITM.ItemName;
                    oItems.ItemsGroupCode = objOITM.ItemGroupCode;
                    oItems.InventoryItem = objOITM.InventoryItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                    oItems.PurchaseItem = objOITM.PurchaseItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                    oItems.SalesItem = objOITM.SalesItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;

                    iRet = oItems.Update();

                    if (iRet == 0)
                    {
                        objOITM.ItemCode = oCompany.GetNewObjectKey();
                        Release(oItems);
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        Release(oItems);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }

                    #endregion
                }
                else
                {
                    #region Crear

                    oItems.Series = objOITM.Series;
                    //oItems.ItemCode = objOITM.ItemCode;
                    oItems.ItemName = objOITM.ItemName;
                    oItems.ItemsGroupCode = objOITM.ItemGroupCode;
                    oItems.InventoryItem = objOITM.InventoryItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                    oItems.PurchaseItem = objOITM.PurchaseItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                    oItems.SalesItem = objOITM.SalesItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;

                    iRet = oItems.Add();

                    if (iRet == 0)
                    {
                        objOITM.ItemCode = oCompany.GetNewObjectKey();
                        Release(oItems);
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetItems(ref csOITM objOITM)
        {
            try
            {
                SAPbobsCOM.Items oItems = oCompany.GetBusinessObject(BoObjectTypes.oItems);
                
                if(oItems.GetByKey(objOITM.ItemCode))
                {
                    objOITM.Series = oItems.Series;
                    objOITM.ItemCode = oItems.ItemCode;
                    objOITM.ItemName = oItems.ItemName;
                    objOITM.ItemGroupCode = oItems.ItemsGroupCode;
                    objOITM.InventoryItem = oItems.InventoryItem == BoYesNoEnum.tYES ? "Y" : "N";
                    objOITM.PurchaseItem = oItems.PurchaseItem == BoYesNoEnum.tYES ? "Y" : "N";
                    objOITM.SalesItem = oItems.SalesItem == BoYesNoEnum.tYES ? "Y" : "N";

                    return true;
                }
                else
                {
                    throw new Exception("Articulo no existe en SAP");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteItems(string sItemCode)
        {
            try
            {
                SAPbobsCOM.Items oItems = oCompany.GetBusinessObject(BoObjectTypes.oItems);

                if (oItems.GetByKey(sItemCode))
                {
                    iRet = oItems.Remove();

                    if(iRet == 0)
                    {
                        return true;
                    }else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
                }
                else
                {
                    throw new Exception("Articulo no existe en SAP");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBusinessPartners(ref csOCRD objBP)
        {
            try
            {
                SAPbobsCOM.BusinessPartners oBP = (SAPbobsCOM.BusinessPartners)oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);

                oBP.Series = objBP.Series;
                //oBP.CardCode = objBP.CardCode;
                oBP.CardName = objBP.CardName;
                oBP.CardType = objBP.CardType == "C" ? BoCardTypes.cCustomer : objBP.CardType == "S" ? BoCardTypes.cSupplier : BoCardTypes.cLid;
                oBP.GroupCode = objBP.GroupCode;
                oBP.FederalTaxID = objBP.LicTradNum;
                oBP.Currency = objBP.Currency;
                oBP.Phone1 = objBP.Phone1;
                oBP.Phone2 = objBP.Phone2;
                oBP.Cellular = objBP.Cellular;
                oBP.Fax = objBP.Fax;
                oBP.MailAddress = objBP.E_Mail;
                oBP.UserFields.Fields.Item("U_CAI").Value = objBP.U_CAI;
                if(objBP.U_Fecha_Vence_Cai != null)
                    oBP.UserFields.Fields.Item("U_Fecha_Vence_Cai").Value = ToDate(objBP.U_Fecha_Vence_Cai);

                //Direcciones
                foreach(csCRD1 objCRD1 in objBP.ListDirec)
                {
                    oBP.Addresses.AddressName = objCRD1.Address;
                    oBP.Addresses.AddressName2 = objCRD1.Address2;
                    oBP.Addresses.Street = objCRD1.Street;
                    oBP.Addresses.Block = objCRD1.Block;
                    oBP.Addresses.City = objCRD1.City;
                    if(objCRD1.State != null) oBP.Addresses.State = objCRD1.State;
                    if(objCRD1.Country != null) oBP.Addresses.Country = objCRD1.Country;
                    oBP.Addresses.AddressType = objCRD1.AdresType == "B" ? BoAddressType.bo_BillTo : BoAddressType.bo_ShipTo;
                    oBP.Addresses.Add();
                }

                //Contactos
                foreach(csOCPR objOCPR in objBP.ListCont)
                {
                    oBP.ContactEmployees.Name = objOCPR.Name;
                    oBP.ContactEmployees.FirstName = objOCPR.FirstName;
                    oBP.ContactEmployees.MiddleName = objOCPR.MiddleName;
                    oBP.ContactEmployees.LastName = objOCPR.LastName;
                    oBP.ContactEmployees.MobilePhone = objOCPR.Cellular;
                    oBP.ContactEmployees.Add();
                }

                iRet = oBP.Add();

                if(iRet == 0)
                {
                    oBP.CardCode = oCompany.GetNewObjectKey();
                    Release(oBP);
                    return true;
                }else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    Release(oBP);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddJournalEntries(ref csOJDT objAsiento)
        {
            try
            {
                SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)oCompany.GetBusinessObject(BoObjectTypes.oJournalEntries);

                oJE.ReferenceDate = ToDate(objAsiento.RefDate);
                oJE.TaxDate = ToDate(objAsiento.TaxDate);
                oJE.DueDate = ToDate(objAsiento.DueDate);
                oJE.Memo = objAsiento.Memo;
                if(objAsiento.Indicator != null && objAsiento.Indicator != "") oJE.Indicator = objAsiento.Indicator;
                if (objAsiento.Project != null && objAsiento.Project != "") oJE.ProjectCode = objAsiento.Project;
                if (objAsiento.Transcode != null && objAsiento.Transcode != "") oJE.TransactionCode = objAsiento.Transcode;
                oJE.Reference = objAsiento.Ref1;
                oJE.Reference2 = objAsiento.Ref2;
                oJE.Reference3 = objAsiento.Ref3;

                foreach(csJDT1 objLines in objAsiento.ListDet)
                {
                    oJE.Lines.AccountCode = objLines.Account;
                    oJE.Lines.ShortName = objLines.ShortName;
                    oJE.Lines.Debit = Double.Parse(objLines.Debit == null ? "0" : objLines.Debit.ToString());
                    oJE.Lines.Credit = Double.Parse(objLines.Credit == null ? "0" : objLines.Credit.ToString());
                    oJE.Lines.FCDebit = Double.Parse(objLines.FCDebit == null ? "0" : objLines.FCDebit.ToString());
                    oJE.Lines.FCCredit = Double.Parse(objLines.FCCredit == null ? "0" : objLines.FCCredit.ToString());
                    oJE.Lines.FCCurrency = objLines.FCCurrency;
                    oJE.Lines.ProjectCode = objLines.Project;
                    oJE.Lines.CostingCode = objLines.OcrCode1;
                    oJE.Lines.CostingCode2 = objLines.OcrCode2;
                    oJE.Lines.CostingCode3 = objLines.OcrCode3;
                    oJE.Lines.CostingCode4 = objLines.OcrCode4;
                    oJE.Lines.CostingCode5 = objLines.OcrCode5;
                }

                iRet = oJE.Add();

                if (iRet == 0)
                {
                    objAsiento.JdtNum = Int32.Parse(oCompany.GetNewObjectKey());
                    Release(oJE);
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    Release(oJE);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Release(object obj)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }

        public static DateTime ToDate(string sFecha)
        {
            try
            {
                //20250313
                //01234567

                DateTime dt = DateTime.Parse(sFecha.Substring(6, 2) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(0, 4));

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

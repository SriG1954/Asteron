using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Contact
{
    public long Id { get; set; }

    public string? Addressbookuid { get; set; }

    public string? Afterhours { get; set; }

    public string? Attorneylicense { get; set; }

    public string? AutopaymentallowedExt { get; set; }

    public long? Autosync { get; set; }

    public long? Beanversion { get; set; }

    public string? Canmanageprojects { get; set; }

    public string? Cellphone { get; set; }

    public long? Claimantidtype { get; set; }

    public string? CommentsExt { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public long? DayperiodExt { get; set; }

    public string Donotdestroy { get; set; } = null!;

    public string? Emailaddress1 { get; set; }

    public string? Emailaddress2 { get; set; }

    public string? Employeenumber { get; set; }

    public string? Faxphone { get; set; }

    public string? Firstname { get; set; }

    public string? Firstnamedenorm { get; set; }

    public string? Formername { get; set; }

    public long? Gender { get; set; }

    public string? Homephone { get; set; }

    public string? IssensitiveExt { get; set; }

    public string? Lastname { get; set; }

    public string? Lastnamedenorm { get; set; }

    public string Loadrelatedcontacts { get; set; } = null!;

    public long? LocationrepairtypeExt { get; set; }

    public string? Makesafe { get; set; }

    public string? Middlename { get; set; }

    public string? Name { get; set; }

    public string? Namedenorm { get; set; }

    public string? Obfuscatedinternal { get; set; }

    public string? Pendinglinkmessage { get; set; }

    public long? Postaladdress { get; set; }

    public string Preferred { get; set; } = null!;

    public long? Prefix { get; set; }

    public long? Primaryaddressid { get; set; }

    public long? Primaryphone { get; set; }

    public string Publicid { get; set; } = null!;

    public long? RepairerrelationshipExt { get; set; }

    public long Retired { get; set; }

    public string? ScAcceptsawpclaims { get; set; }

    public string? ScAcceptsdriveable { get; set; }

    public string? ScAcceptsnondriveable { get; set; }

    public string? ScAcceptssms { get; set; }

    public string? ScAcceptstpafclaims { get; set; }

    public string? ScAcceptstpvehicles { get; set; }

    public string? ScAcceptsume { get; set; }

    public string? ScAccidentsequencekey { get; set; }

    public string? ScAccountname { get; set; }

    public string? ScAccountnumber { get; set; }

    public string? ScActivecontact { get; set; }

    public string? ScActivepnetaccount { get; set; }

    public string? ScAuthparty { get; set; }

    public string? ScB2bEnabled { get; set; }

    public string? ScBankname { get; set; }

    public string? ScBsb { get; set; }

    public string? ScBulkpayments { get; set; }

    public long? ScBusinesstype { get; set; }

    public string? ScCellphone { get; set; }

    public string? ScCentralbillservice { get; set; }

    public string? ScConsolvendor { get; set; }

    public long? ScContactpaymentaccountseq { get; set; }

    public long? ScCorrespondencedelivery { get; set; }

    public string? ScDeceased { get; set; }

    public string? ScFormerfirstname { get; set; }

    public string? ScFormermiddlename { get; set; }

    public string? ScGstregistered { get; set; }

    public string? ScHospitalname { get; set; }

    public string? ScInterpreterreqd { get; set; }

    public long? ScLanguage { get; set; }

    public long? ScLanguagepref { get; set; }

    public long? ScLocationtype { get; set; }

    public long? ScNodependantadults { get; set; }

    public long? ScNodependantchildren { get; set; }

    public string? ScOpenfriday { get; set; }

    public string? ScOpenmonday { get; set; }

    public string? ScOpensaturday { get; set; }

    public string? ScOpensunday { get; set; }

    public string? ScOpenthursday { get; set; }

    public string? ScOpentuesday { get; set; }

    public string? ScOpenwednesday { get; set; }

    public string? ScOtherphone { get; set; }

    public string? ScOtherphonedesc { get; set; }

    public string? ScPayable { get; set; }

    public long? ScPaymentmethod { get; set; }

    public string? ScPaymentname { get; set; }

    public DateTime? ScPaymentserviceackdate { get; set; }

    public string? ScPaymentservicecorrid { get; set; }

    public string? ScPaymentservicevendorid { get; set; }

    public long? ScPaymentterms { get; set; }

    public DateTime? ScPaystartdate { get; set; }

    public long? ScPolicytype { get; set; }

    public string? ScPortfoliocode { get; set; }

    public string? ScProcesstypeexists { get; set; }

    public string? ScRecommended { get; set; }

    public long? ScRemittancedelivery { get; set; }

    public string? ScRemittancenotificationemail { get; set; }

    public string? ScSamenotificationemail { get; set; }

    public string? ScSamenotificationsms { get; set; }

    public string? ScServiceablepostcodenational { get; set; }

    public string? ScStaffnumber { get; set; }

    public string? ScSuspended { get; set; }

    public string? ScTradingname { get; set; }

    public long? ScVendorengagementtype { get; set; }

    public long? ScVendortype { get; set; }

    public long Subtype { get; set; }

    public long? Suffix { get; set; }

    public string? Taxid { get; set; }

    public long? Taxstatus { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }

    public long? Vendortype { get; set; }

    public string? W9received { get; set; }

    public string? WatchlistproviderExt { get; set; }

    public string? Workphone { get; set; }
}

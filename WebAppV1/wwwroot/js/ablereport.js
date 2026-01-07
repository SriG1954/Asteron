
function Downloadarsfiles(url) {
    window.open(url, "", "width=600, height=500");
}

function GetAppName(appid) {
    appname = "Able";
    if (appid == "2") {
        appname = "Orion";
    }
    return appname;
}

function GetSiteLog(id) {
    //-------------------------------------------
    // Able SiteLog
    //-------------------------------------------

    $.ajax({
        url: '/AbleLogs/GetSiteLog',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able SiteLog');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetAbleSiteUser(id) {
    //-------------------------------------------
    // Able AbleSiteUser
    //-------------------------------------------

    $.ajax({
        url: '/AbleUsers/GetAbleSiteUser',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able AbleSiteUser');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetClaimbenefitmv(id, appId) {
    //-------------------------------------------
    // Able Claimbenefitmv
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetClaimbenefitmv',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Claimbenefitmv');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMedicalCode(id, appId) {
    //-------------------------------------------
    // Able MedicalCode
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetMedicalCode',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' MedicalCode');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMedicalCode1(id, appId) {
    //-------------------------------------------
    // Able MedicalCode
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetMedicalCode',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' MedicalCode');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetCoverageSearch(id) {
    //-------------------------------------------
    // Able CoverageSearch
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetCoverageSearch',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able CoverageSearch');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPaymentsummarymv(id, appId) {
    //-------------------------------------------
    // Able Paymentsummarymv
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetPaymentsummarymv',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Paymentsummarymv');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetTaskmv(id) {
    //-------------------------------------------
    // Able Taskmv
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetTaskmv',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able Taskmv');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptAbleuser(id) {
    //-------------------------------------------
    // Able RptAbleuser
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptAbleuser',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptAbleuser');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptAbleusersallrole(id) {
    //-------------------------------------------
    // Able RptAbleusersallrole
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptAbleusersallrole',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptAbleusersallrole');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptActionsservice(id) {
    //-------------------------------------------
    // Able RptActionsservice
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptActionsservice',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptActionsservice');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptCaseaction(id) {
    //-------------------------------------------
    // Able RptCaseaction
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCaseaction',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCaseaction');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimbenefitactuarialrec(id) {
    //-------------------------------------------
    // Able RptClaimbenefitactuarialrec
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimbenefitactuarialrec',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimbenefitactuarialrec');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimBenefitactuarialrecl(id) {
    //-------------------------------------------
    // Able RptClaimBenefitactuarialrecl
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimBenefitactuarialrecl',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimBenefitactuarialrecl');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimbenefitgroup(id) {
    //-------------------------------------------
    // Able RptClaimbenefitgroup
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimbenefitgroup',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimbenefitgroup');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimbenefitreinsurance(id) {
    //-------------------------------------------
    // Able RptClaimbenefitreinsurance
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimbenefitreinsurance',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimbenefitreinsurance');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimbenefitw(id) {
    //-------------------------------------------
    // Able RptClaimbenefitw
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimbenefitw',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimbenefitw');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimcasedecipha(id) {
    //-------------------------------------------
    // Able RptClaimcasedecipha
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimcasedecipha',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimcasedecipha');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimexpense(id) {
    //-------------------------------------------
    // Able RptClaimexpense
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimexpense',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimexpense');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClaimparticipant(id) {
    //-------------------------------------------
    // Able RptClaimparticipant
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClaimparticipant',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClaimparticipant');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetRptClosedtaskreport(id) {
    //-------------------------------------------
    // Able RptClosedtaskreport
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptClosedtaskreport',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptClosedtaskreport');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptCmpaction(id) {
    //-------------------------------------------
    // Able RptCmpaction
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCmpaction',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCmpaction');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptCmpgoaldatemovement(id) {
    //-------------------------------------------
    // Able RptCmpgoaldatemovement
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCmpgoaldatemovement',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCmpgoaldatemovement');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptCmpplanstatus(id) {
    //-------------------------------------------
    // Able RptCmpplanstatus
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCmpplanstatus',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCmpplanstatus');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptCmpservice(id) {
    //-------------------------------------------
    // Able RptCmpservice
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCmpservice',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCmpservice');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptCompliant(id) {
    //-------------------------------------------
    // Able RptCompliant
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptCompliant',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptCompliant');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptDocumentreport(id) {
    //-------------------------------------------
    // Able RptDocumentreport
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptDocumentreport',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptDocumentreport');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptEnquirycasereport(id) {
    //-------------------------------------------
    // Able RptEnquirycasereport
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptEnquirycasereport',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptEnquirycasereport');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptHcrcompletednote(id) {
    //-------------------------------------------
    // Able RptHcrcompletednote
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptHcrcompletednote',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptHcrcompletednote');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptOpentask(id) {
    //-------------------------------------------
    // Able RptOpentask
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptOpentask',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptOpentask');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptOverrideriskreport(id) {
    //-------------------------------------------
    // Able RptOverrideriskreport
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptOverrideriskreport',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptOverrideriskreport');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptPaymentsummaryl(id) {
    //-------------------------------------------
    // Able RptPaymentsummaryl
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptPaymentsummaryl',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptPaymentsummaryl');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptPhoneenquiry(id) {
    //-------------------------------------------
    // Able RptPhoneenquiry
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptPhoneenquiry',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptPhoneenquiry');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptRecoveryrehabnote(id) {
    //-------------------------------------------
    // Able RptRecoveryrehabnote
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptRecoveryrehabnote',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptRecoveryrehabnote');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptTaskreportgroup(id) {
    //-------------------------------------------
    // Able RptTaskreportgroup
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptTaskreportgroup',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptTaskreportgroup');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetRptTaskreportreinsurance(id) {
    //-------------------------------------------
    // Able RptTaskreportreinsurance
    //-------------------------------------------

    $.ajax({
        url: '/AbleReports/GetRptTaskreportreinsurance',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able RptTaskreportreinsurance');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetParty(id, appId) {
    //-------------------------------------------
    // Able Party
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetParty',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Party');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPartyAddress(id, appId) {
    //-------------------------------------------
    // Able PartyAddress
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetPartyAddress',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' PartyAddress');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPartyAddressById(c, i) {
    //-------------------------------------------
    // Able GetPartyAddressById
    //-------------------------------------------

    $.ajax({
        url: '/AbleParties/GetPartyAddressById',
        type: 'Post',
        data: {
            C: c,
            I: i
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able PartyAddress');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPartyContact(id) {
    //-------------------------------------------
    // Able PartyContact
    //-------------------------------------------

    $.ajax({
        url: '/AbleParties/GetPartyContact',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able PartyContact');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPartyContactById(c, i) {
    //-------------------------------------------
    // Able GetPartyContactById
    //-------------------------------------------

    $.ajax({
        url: '/AbleParties/GetPartyContactById',
        type: 'Post',
        data: {
            C: c,
            I: i
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able PartyContact');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetCase(id, appId) {
    //-------------------------------------------
    // Able Case
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetCaseDetail',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Case');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetClaim(id) {
    //-------------------------------------------
    // Able Claim
    //-------------------------------------------

    $.ajax({
        url: '/AbleClaims/GetClaim',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able Claim');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetTabSearchResult() {
    // make visible spinne
    document.getElementById("myspinner").style.visibility = "visible";
    //$('body').style.filter = "contrast(25%)";

    var claimNumber = $("#claimnumber").val();
    column = document.getElementById("tabsearch");
    columnText = column.options[column.selectedIndex].text;
    columnValue = column.options[column.selectedIndex].value;
    var myurl = '';

    if (columnValue == 'CaseDetails') {
        myurl = '/AbleTabs/GetClaimBenefitDetail';
    } else if (columnValue == 'Tasks') {
        myurl = '/AbleTabs/GetTasksByClaimNumber';
    } else if (columnValue == 'Documents') {
        myurl = '/AbleTabs/GetDocumentsByClaimNumber';
    } else if (columnValue == 'Actions') {
        myurl = '/AbleTabs/GetActionsByClaimNumber';
    } else if (columnValue == 'Participants') {
        myurl = '/AbleTabs/GetParticipantsByClaimNumber';
    }

    //-------------------------------------------
    // Able Claim Hub
    //-------------------------------------------

    $.ajax({
        url: myurl,
        type: 'Post',
        data: {
            ID: claimNumber
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            //$('#modalTitle').html('Able Claim');
            $('#tbltabsearch').empty();
            $('#tbltabsearch').html(result);
            //$('#myModal').modal('show');
        }

        //$('body').style.filter = "contrast(100%)";

        // hide spinner
        document.getElementById("myspinner").style.visibility = "hidden";
    });
}

function GetPolicy(id, appId) {
    //-------------------------------------------
    // Able Policy
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetPolicy',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Policy');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetBenefit(id, appId) {
    //-------------------------------------------
    // Able Benefit
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetBenefit',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Benefit');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetNote1(id, appId) {
    //-------------------------------------------
    // Able Note2
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetNote1',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Notes');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetDocument(id, appId) {
    //-------------------------------------------
    // Able Document
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetDocument',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Document');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetCaseValidation(id) {
    //-------------------------------------------
    // Able CaseValidation
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetCaseValidation',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able CaseValidation');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetOutstandingRequest(id) {
    //-------------------------------------------
    // Able OutstandingRequest
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetOutstandingRequest',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able OutstandingRequest');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetTaskA(id, appId) {
    //-------------------------------------------
    // Able TaskA
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetTaskA',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' TaskA');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetContact(id) {
    //-------------------------------------------
    // Able Contact
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetContact',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able Contact');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetContact1(id, appId) {
    //-------------------------------------------
    // Able Contact
    //-------------------------------------------

    $.ajax({
        url: '/Able/GetContact',
        type: 'Post',
        data: {
            ID: id,
            AppID: appId
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html(GetAppName(appId) + ' Contact');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetOccupation(id) {
    //-------------------------------------------
    // Able Occupation
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetOccupation',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able Occupation');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetClaimOccupation(id) {
    //-------------------------------------------
    // Able ClaimOccupation
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetClaimOccupation',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able ClaimOccupation');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}



function GetClaimPeriod(id) {
    //-------------------------------------------
    // Able ClaimPeriod
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetClaimPeriod',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able ClaimPeriod');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetClientGoal(id) {
    //-------------------------------------------
    // Able ClientGoal
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetClientGoal',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able ClientGoal');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetGoal(id) {
    //-------------------------------------------
    // Able Goal
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetGoal',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able Goal');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetActionA(id) {
    //-------------------------------------------
    // Able ActionA
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetActionA',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able ActionA');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetLifeArea(id) {
    //-------------------------------------------
    // Able LifeArea
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetLifeArea',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able LifeArea');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetWorkStatus(id) {
    //-------------------------------------------
    // Able ClaimIncapacityPeriod
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetWorkStatus',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able GetWorkStatus');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetActionHistory(id) {
    //-------------------------------------------
    // Able ActionHistory
    //-------------------------------------------

    $.ajax({
        url: '/AbleTabs/GetActionHistory',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able ActionHistory');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetAbleIssue(id) {
    //-------------------------------------------
    // Able AbleIssue
    //-------------------------------------------

    $.ajax({
        url: '/AbleIssues/GetAbleIssue',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Able AbleIssue');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


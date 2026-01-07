
function onlyNumberKey(evt) {
    // Only ASCII charactar in that range allowed 
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode > 31 && (ASCIICode < 43 || ASCIICode > 57))
        return false;
    return true;
}

function onlyNumberKey1(evt) {
    // Only ASCII charactar in that range allowed 
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    //alert(ASCIICode);
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
}

function onlyNumberKeyOld(evt) {
    // Only ASCII charactar in that range allowed 
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    //alert(ASCIICode);
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
}

function onlyNumberKeyRegex(evt) {
    // Only ASCII charactar in that range allowed 
    var input = (evt.which) ? evt.which : evt.keyCode
    var regex = new RegExp("/^\$?[0-9][0-9,]*[0-9]\.?[0-9]{0,2}$/i");
    if (regex.test(input)) {
        alert("true");
    } else {
        alert("false");
        return false;
    }
}

function validateForm(evt) {
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    alert(ASCIICode);
    if (ASCIICode == 32) {
        SearchClientsEx();
    }
}

function closeModal() {
    $('#myModal').modal('hide');
}

function GetMyClaim(id) {
    $.ajax({
        url: '/FigClaims/GetFigClaim',
        type: 'Post',
        data: {
            claimId: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetReportclaim(id) {
    $.ajax({
        url: '/FigClaims/GetReportClaim',
        type: 'Post',
        data: {
            id: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetMyAllAddress(id) {
    $.ajax({
        url: '/FigAddress/GetFigAddress',
        type: 'Post',
        data: {
            id: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Address Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyNote(id) {
    $.ajax({
        url: '/FigNotes/GetMyNote',
        type: 'Post',
        data: {
            claimId: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Note');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetMyNoteItem(id) {
    $.ajax({
        url: '/FigNotes/GetMyNoteItem',
        type: 'Post',
        data: {
            id: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Note');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetMyTask(id) {
    $.ajax({
        url: '/FigTasks/GetMyTask',
        type: 'Post',
        data: {
            claimId: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Task');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetTaskItem(id) {
    $.ajax({
        url: '/FigTasks/GetTaskItem',
        type: 'Post',
        data: {
            id: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Claim Task');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyLife(rowid) {
    $.ajax({
        url: '/FigLife/GetMyLife',
        type: 'Post',
        data: {
            rowid: rowid
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Life Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyPlan(policy) {
    $.ajax({
        url: '/FigPlan/GetMyPlan',
        type: 'Post',
        data: {
            policy: policy,
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Plan Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyEmployee(employeeNo) {
    $.ajax({
        url: '/FigEmployee/GetMyEmployee',
        type: 'Post',
        data: {
            employeeNo: employeeNo,
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Employee Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyErrorLog(id) {
    $.ajax({
        url: '/ErrorLogs/GetMyErrorLog',
        type: 'Post',
        data: {
            id: id,
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('ErrorLog Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyEmail(id) {
    $.ajax({
        url: '/Emails/GetMyEmail',
        type: 'Post',
        data: {
            id: id,
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Email Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetMyIssue(id) {
    $.ajax({
        url: '/FigIssues/GetMyIssue',
        type: 'Post',
        data: {
            id: id,
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Issue Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}


function GetReportClaim(id) {
    var mysearch = $('#txtsearch').val();
    var mytype = $('#claimtype').val();
    if (mysearch == "") {
        alert('Enter Claim Number');
        $('#txtsearch').focus();
        return;
    } else {
        //alert(mysearch);
        if (mytype == "claim") {
            $('#mydownload').attr("href", "/Download/GetClaim?id=" + id);
        } else if (mytype == "tasks") {
            $('#mydownload').attr("href", "/Download/GetTasks?column=FReferenceNo&search=" + mysearch + "&pageIndex=1&pageSize=1000");
        } else if (mytype == "notes") {
            $('#mydownload').attr("href", "/Download/GetNotes?column=FIncidentNumber&search=" + mysearch + "&pageIndex=1&pageSize=1000");
        }
        return;
    }
}

function GetReportSearch() {
    var mysearch = $('#txtsearch').val();
    var mycolumn = $('#column').val();
    var mytype = $('#claimtype').val();
    var myurl = "";

    if (mysearch == "") {
        alert('Enter Claim Number');
        $('#txtsearch').focus();
        return;
    } else {
        //alert(mycolumn + ' ' + mysearch);
        if (mytype == "claim") {
            myurl = "/FigClaims/GetAlllsclaimByClaimNo"
        } else if (mytype == "tasks") {
            myurl = "/FigTasks/TaskReport"
        } else if (mytype == "notes") {
            myurl = "/FigNotes/NoteReport"
        }

        $.ajax({
            url: myurl,
            type: 'Post',
            data: {
                column: mycolumn,
                search: mysearch,
                pageIndex: 1,
                pageSize: 1000
            },
            cache: false,
        }).done(function (result) {
            //alert(result);
            if (result != "NO") {
                $('#claimsearch').empty();
                $('#claimsearch').html(result);
            }
        });
    }
}

function GetSearchClaim() {
    var mysearch = $('#txtsearch').val();
    var mytype = $('#claimtype').val();
    if (mysearch == "") {
        alert('Enter Claim Number');
        $('#txtsearch').focus();
        return;
    } else {
        //alert(mysearch);
        if (mytype == "claim") {
            $('#mydownload').attr("href", "/Download/GetClaim?id=" + mysearch);
        } else if (mytype == "tasks") {
            $('#mydownload').attr("href", "/Download/GetTasks?column=FReferenceNo&search=" + mysearch + "&pageIndex=1&pageSize=1000");
        } else if (mytype == "notes") {
            $('#mydownload').attr("href", "/Download/GetNotes?column=FIncidentNumber&search=" + mysearch + "&pageIndex=1&pageSize=1000");
        }
        return;
    }
}

function GetPAYGReporting(id) {
    $.ajax({
        url: '/PAYGReportings/Details',
        type: 'Post',
        data: {
            id: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('PAYG Reporting Data');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetClaimType() {
    return $('#ClaimType').val();
}

function GetSource() {
    return $('#Source').val();
}

function ValidatePayeeProportionMethod() {

    var payeeProportionMethod = $('#PayeeProportionMethod').val();

    if (payeeProportionMethod == "PERCENT") {
        $('#PayeePercent').prop('disabled', false);
        $('#PayeeFixedBenefit').prop('disabled', true);
    } else {
        $('#PayeePercent').prop('disabled', true);
        $('#PayeeFixedBenefit').prop('disabled', false);
    };

    return true;
}

function ValidatePayeeName() {
    var claimType = $('#ClaimType').val();
    var lifeInsureGivenName = $('#LifeInsureGivenName').val();
    var lifeInsureSurname = $('#LifeInsureSurname').val();

    if (claimType.toLowerCase() == ("death")) {
        var payeename = "Est Late " & lifeInsureGivenName & " " & lifeInsureSurname
        $("#PayeeTitle").text(payeename);
    }
}

function ValidatePayeePaymentType() {

    var claimType = $('#ClaimType').val();
    var source = $('#Source').val();
    var payeePaymentType = $('#PayeePaymentType').val();

    if (claimType.toLowerCase() == ("death")) {
        document.getElementById("PayeePaymentType").selectedIndex = 1;
    } 

    return true;
}

function ValidatePayeePayeeType() {

    var claimType = $('#ClaimType').val();
    var payeePayeeType = $('#PayeePayeeType').val();

    if (payeePayeeType.toLowerCase() == ("fd")) {
        alert("For a Death claim select either NFD or Estate!")
        document.getElementById("PayeePayeeType").selectedIndex = 0;
        return false;
    }

    return true;
}


function ValidatePaymentClaim() {

    var claimNo = $('#ClaimNo').val();
    var policyNo = $('#PolicyNo').val();
    var lifeInsureTitle = $('#LifeInsureTitle').val();
    var lifeInsureGivenName = $('#LifeInsureGivenName').val();
    var lifeInsureSurname = $('#LifeInsureSurname').val();
    var lifeInsureDOB = $('#LifeInsureDOB').val();
    var lifeInsureESD = $('#LifeInsureESD').val();
    var lifeInsureDateCeased = $('#LifeInsureDateCeased').val();
    var lifeInsureNRAge = $('#LifeInsureNRAge').val();

    if (policyNo == "" && claimNo == "") {
        alert("Enter Policy or Claim number and try again");
        return false;
    }

    if (lifeInsureTitle == "" || lifeInsureGivenName == "" || lifeInsureSurname == "") {
        alert("Enter Title, Surname and GivenName and then try again");
        return false;
    }

    if (lifeInsureDOB == "" || lifeInsureESD == "" || lifeInsureDateCeased == "" || lifeInsureNRAge == "") {
        alert("Enter DOB, ESD, DateCeased and Retirement age and then try again");
        return false;
    }

    var payeeProportionMethod = $('#PayeeProportionMethod').val();

    if (payeeProportionMethod == "PERCENT") {
        $('#PayeePercent').prop('disabled', false);
        $('#PayeeFixedBenefit').prop('disabled', true);
    } else {
        $('#PayeePercent').prop('disabled', true);
        $('#PayeeFixedBenefit').prop('disabled', false);
    };

    return true;
}

function ValidateSource() {
    var column = null;
    var columnValue = null;
    var columnText = null;

    column = document.getElementById("ClaimType");
    columnText = column.options[column.selectedIndex].text;
    columnValue = column.options[column.selectedIndex].value;

    if (columnText == "Death") {
        document.getElementById("Source").selectedIndex = 1;
        document.getElementById("PayeePaymentType").selectedIndex = 1;
    }
}

function GetPyerIdentity() {

    var column = null;
    var columnValue = null;
    var columnText = null;

    column = document.getElementById("PayerIdentity");
    columnText = column.options[column.selectedIndex].text;
    columnValue = column.options[column.selectedIndex].value;

    $.ajax({
        url: '/PAYGClaims/GetPyerIdentity',
        type: 'Post',
        data: {
            id: columnValue,
        },
        cache: false,
    }).done(function (result) {
        alert(result);
        const data = result.split(",")
        document.getElementById("PayerContactName").value = data[0];
        document.getElementById("PayerContactTelephone").value = data[1];
        document.getElementById("PayerTrust").value = data[2];
        document.getElementById("PayerABN").value = data[3];
        document.getElementById("PayerSignatory").value = data[0];
        document.getElementById("PayerSignatoryImage").value = data[6];

    });
}

function ValidatePaymentClaimSelections() {

    ValidateSource();

    claimType = $("#ClaimType").val();
    source = $("#Source").val();
    crystallisationOptions = $("#CrystallisationOptions").val();
    payeeProportionMethod = $("#PayeeProportionMethod").val();
    payeePayeeType = $("#PayeePayeeType").val();
    payeePaymentType = $("#PayeePaymentType").val();
    payerIdentity = $("#PayerIdentity").val();


    if (claimType.toLowerCase().includes("select")) {
        alert("Select a ClaimType and try again")
        document.getElementById("ClaimType").selectedIndex = 1;
        return false;
    }

    if (source.toLowerCase().includes("select")) {
        alert("Select a Source and try again")
        document.getElementById("Source").selectedIndex = 1;
        return false;
    }

    if (crystallisationOptions.toLowerCase().includes("select")) {
        alert("Select a Crystallisation Options and try again")
        document.getElementById("CrystallisationOptions").selectedIndex = 1;
        return false;
    }

    if (payeeProportionMethod.toLowerCase().includes("select")) {
        alert("Select a Payee Proportion Method and try again")
        document.getElementById("PayeeProportionMethod").selectedIndex = 1;
        return false;
    }

    if (payeePayeeType.toLowerCase().includes("select")) {
        alert("Select a Payee PayeeType and try again")
        document.getElementById("PayeePayeeType").selectedIndex = 1;
        return false;
    }

    if (payeePaymentType.toLowerCase().includes("select")) {
        alert("Select a Payee PaymentType and try again")
        document.getElementById("PayeePaymentType").selectedIndex = 1;
        return false;
    }

    if (payerIdentity.toLowerCase().includes("select")) {
        alert("Select a Payer and try again")
        document.getElementById("PayerIdentity").selectedIndex = 1;
        return false;
    }

    return true;
}

function ValidateSuperBenefit() {

    $.ajax({
        url: '/PaymentClaims/ValidateSuperBenefit',
        async: false,
        type: 'Post',
        data: {
            ID: $('#ID').val(),
            PolicyNo: $('#PolicyNo').val(),
            ClaimType: $("#ClaimType").val(),
            Source: $("#Source").val(),
            ClaimNo: $('#ClaimNo ').val(),
            UserId: $('#UserId ').val(),
            ParentId: $('#ParentId ').val(),
            LifeInsureTitle: $('#LifeInsureTitle ').val(),
            LifeInsureSurname: $('#LifeInsureSurname ').val(),
            LifeInsureGivenName: $('#LifeInsureGivenName ').val(),
            LifeInsureSecondGivenName: $('#LifeInsureSecondGivenName ').val(),
            LifeInsureDOB: $('#LifeInsureDOB ').val(),
            LifeInsureESD: $('#LifeInsureESD ').val(),
            LifeInsureDateCeased: $('#LifeInsureDateCeased ').val(),
            LifeInsureNRAge: $('#LifeInsureNRAge ').val(),
            DateOfPayment: $('#DateOfPayment ').val(),
            Benefit: $('#Benefit ').val(),
            AD: $('#AD').val(),
            Insured: $('#Insured ').val(),
            CrystallisationOptions: $('#CrystallisationOptions ').val(),
            CrysPV2007: $('#CrysPV2007 ').val(),
            CrysESD2007: $('#CrysESD2007 ').val(),
            CrysConc2007: $('#CrysConc2007 ').val(),
            CrysInv2007: $('#CrysInv2007 ').val(),
            CrysUDC2007: $('#CrysUDC2007 ').val(),
            CrysCrysTaxFree: $('#CrysCrysTaxFree ').val(),
            CrysTaxFreeInOut: $('#CrysTaxFreeInOut ').val(),
            CrysNonConcInOut: $('#CrysNonConcInOut ').val(),
            TaxFree: $('#TaxFree ').val(),
            PayeeProportionMethod: $('#PayeeProportionMethod ').val(),
            PayeePercent: $('#PayeePercent ').val(),
            PayeeFixedBenefit: $('#PayeeFixedBenefit ').val(),
            PayeePayeeType: $('#PayeePayeeType ').val(),
            PayeePaymentType: $('#PayeePaymentType ').val(),
            PayeeTransitional: $('#PayeeTransitional ').val(),
            PayeeTitle: $('#PayeeTitle ').val(),
            PayeeSurname: $('#PayeeSurname ').val(),
            PayeeGivenName: $('#PayeeGivenName ').val(),
            PayeeDOB: $('#PayeeDOB ').val(),
            PayeeSex: $('#PayeeSex ').val(),
            PayeeTFN: $('#PayeeTFN ').val(),
            PayeeCompany: $('#PayeeCompany ').val(),
            PayeeAddress1: $('#PayeeAddress1 ').val(),
            PayeeAddress2: $('#PayeeAddress2 ').val(),
            PayeeCity: $('#PayeeCity ').val(),
            PayeeState: $('#PayeeState ').val(),
            PayeePostCode: $('#PayeePostCode ').val(),
            PayeeCountry: $('#PayeeCountry ').val(),
            PayeePhone: $('#PayeePhone ').val(),
            PayeeEmail: $('#PayeeEmail ').val(),
            RolloverABN: $('#RolloverABN ').val(),
            RolloverName: $('#RolloverName ').val(),
            RolloverAddress1: $('#RolloverAddress1 ').val(),
            RolloverAddress2: $('#RolloverAddress2 ').val(),
            RolloverCity: $('#RolloverCity ').val(),
            RolloverState: $('#RolloverState ').val(),
            RolloverPostCode: $('#RolloverPostCode ').val(),
            RolloverSPIN: $('#RolloverSPIN ').val(),
            RolloverAccountNo: $('#RolloverAccountNo ').val(),
            RolloverRestricted: $('#RolloverRestricted ').val(),
            RolloverUnrestricted: $('#RolloverUnrestricted ').val(),
            RolloverSurchFinancialYear: $('#RolloverSurchFinancialYear ').val(),
            RolloverSurchEmployerConts: $('#RolloverSurchEmployerConts ').val(),
            RolloverSurchPersonalConts: $('#RolloverSurchPersonalConts ').val(),
            RolloverSurchETP: $('#RolloverSurchETP ').val(),
            PayerContactName: $('#PayerContactName ').val(),
            PayerContactTelephone: $('#PayerContactTelephone ').val(),
            PayerIdentity: $('#PayerIdentity ').val(),
            PayerTrust: $('#PayerTrust ').val(),
            PayerABN: $('#PayerABN ').val(),
            PayerName: $("#PayerIdentity").val(),
            PayerSignatory: $('#PayerSignatory ').val(),
            PayerSignatoryImage: $('#PayerSignatoryImage ').val(),
            CalcCrysTaxFree: $('#CalcCrysTaxFree ').val(),
            CalcTaxFreeRollovers: $('#CalcTaxFreeRollovers ').val(),
            CalcNonConc: $('#CalcNonConc ').val(),
            CalcPost94IC: $('#CalcPost94IC ').val(),
            CalcPre83: $('#CalcPre83 ').val(),
            CalcTaxFree: $('#CalcTaxFree ').val(),
            CalcTaxed: $('#CalcTaxed ').val(),
            CalcUntaxed: $('#CalcUntaxed ').val(),
            CalcTaxable: $('#CalcTaxable ').val(),
            CalcGrossBenefit: $('#CalcGrossBenefit ').val(),
            CalcTax: $('#CalcTax ').val(),
            CalcNetBenefit: $('#CalcNetBenefit ').val(),
            IsClaimValidated: $('#IsClaimValidated ').val(),
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('PAYG Claim');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');

            return false;
        }
    });

    return true;
}

function UpdatePayeeDetails() {

    var claimType = $("#ClaimType").val();
    var LifeInsureTitle = $("#LifeInsureTitle").val();
    var lifeInsureGivenName = $("#LifeInsureGivenName").val();
    var lifeInsureSurname = $("#LifeInsureSurname").val();

    // insured visible for death
    // date ceased employment visible for disability/tib
    // payee type visible for death
    // payment type visible for death/tib
    // payee company name visible for death
    // AD visible for death
    // Retirement age visible for death/disability/tib
    
    if (claimType == "Death") {
        // change payee title
        $("#lblPayeeTitle").text("Estate");
        $("#PayeeTitle").val("Est Late");

        // disable date ceased
        $("#LifeInsureDateCeased").prop('disabled', true);
    }
    else if (claimType == "Disability") {
        // disable AD
        $("#AD").prop('disabled', true);

        // disable payee company name
        $("#PayeeCompany").prop('disabled', true);

        // disable insured
        $("#Insured").prop('disabled', true);
    }
    else if (claimType == "Withdrawal") {
        // disable AD
        $("#AD").prop('disabled', true);

        // disable retirement age
        $("#LifeInsureNRAge").prop('disabled', true);

        // disable payee company name
        $("#PayeeCompany").prop('disabled', true);

        // disable insured
        $("#Insured").prop('disabled', true);
    }
    else {
        $("#PayeeTitle").val(LifeInsureTitle);
    }

    $("#PayeeGivenName").val(lifeInsureGivenName);
    $("#PayeeSurname").val(lifeInsureSurname);

    return true;
}

function GetClaim(id) {
    //-------------------------------------------
    // Asteron Claim
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetClaim',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Claim');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetPolicy(id) {
    //-------------------------------------------
    // Asteron Policy
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetPolicy',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Policy');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetNote(id) {
    //-------------------------------------------
    // Asteron Note
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetNote',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Note');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetDocument(id) {
    //-------------------------------------------
    // Asteron Document
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetDocument',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Document');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetActivity(id) {
    //-------------------------------------------
    // Asteron Activity
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetActivity',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Activity');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetHistory(id) {
    //-------------------------------------------
    // Asteron History
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetHistory',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron History');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetContact(id) {
    //-------------------------------------------
    // Asteron Contact
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetContact',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Contact');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetAddress(id) {
    //-------------------------------------------
    // Asteron Address
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetAddress',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Address');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetCoverage(id) {
    //-------------------------------------------
    // Asteron Coverage
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetCoverage',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Coverage');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetIncident(id) {
    //-------------------------------------------
    // Asteron Incident
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetIncident',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Incident');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}

function GetComplaint(id) {
    //-------------------------------------------
    // Asteron Complaint
    //-------------------------------------------

    $.ajax({
        url: '/Asteron/GetComplaint',
        type: 'Post',
        data: {
            ID: id
        },
        cache: false,
    }).done(function (result) {
        //alert(result);
        if (result != "NO") {
            $('#modalTitle').html('Asteron Complaint');
            $('#SelectTargetId').empty();
            $('#SelectTargetId').html(result);
            $('#myModal').modal('show');
        }
    });
}
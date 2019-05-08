$(document).ready(() => {
	manageCourt();
	manageAttorney();
	manageProsecution();
	manageDefense();
	manageRecipient();
});

//prosecution
let manageProsecution = () => {
	let isEnabled = true;
	$('.newProsecutionButton').click((e) => {
		if (isEnabled) {
			enableProsecutionList(e);
		} else {
			enableProsecutionInfo(e);
		}
		isEnabled = !isEnabled;
	});
}

let enableProsecutionList = (e) => {
	e.preventDefault();
	$("#newProsecutionValue").val(false);
	$("#ProsecutionListInput").show();
	$("#ProsecutionInfoInput").hide();
}

let enableProsecutionInfo = (e) => {
	e.preventDefault();
	$("#newProsecutionValue").val(true);
	$("#ProsecutionListInput").hide();
	$("#ProsecutionInfoInput").show();
}

//defense
let manageDefense = () => {
	let isEnabled = true;
	$('.newDefenseButton').click((e) => {
		if (isEnabled) {
			enableDefenseList(e);
		} else {
			enableDefenseInfo(e);
		}
		isEnabled = !isEnabled;
	});
}

let enableDefenseList = (e) => {
	e.preventDefault();
	$("#newDefenseValue").val(false);
	$("#DefenseListInput").show();
	$("#DefenseInfoInput").hide();
}

let enableDefenseInfo = (e) => {
	e.preventDefault();
	$("#newDefenseValue").val(true);
	$("#DefenseListInput").hide();
	$("#DefenseInfoInput").show();
}

//recipient
let manageRecipient = () => {
	let isEnabled = true;
	$('.newRecipientButton').click((e) => {
		if (isEnabled) {
			enableRecipientList(e);
		} else {
			enableRecipientInfo(e);
		}
		isEnabled = !isEnabled;
	});
}

let enableRecipientList = (e) => {
	e.preventDefault();
	$("#newRecipientValue").val(false);
	$("#RecipientListInput").show();
	$("#RecipientInfoInput").hide();
}

let enableRecipientInfo = (e) => {
	e.preventDefault();
	$("#newRecipientValue").val(true);
	$("#RecipientListInput").hide();
	$("#RecipientInfoInput").show();
}

//court
let manageCourt = () => {
	let isEnabled = true;
	$('.newCourtButton').click((e) => {
		if (isEnabled) {
			enableCourtList(e);
		} else {
			enableCourtName(e);
		}
		isEnabled = !isEnabled;
	});
}

let enableCourtList = (e) => {
	e.preventDefault();
	$("#newCourtValue").val(false);
	$("#CourtListInput").show();
	$("#CourtNameInput").hide();
}

let enableCourtName = (e) => {
	e.preventDefault();
	$("#newCourtValue").val(true);
	$("#CourtNameInput").show();
	$("#CourtListInput").hide();
}

//attorney
let manageAttorney = () => {
	let isEnabled = true;
	$('.newAttorneyButton').click((e) => {
		if (isEnabled) {
			enableAttorneyList(e);
		} else {
			enableAttorneyInfo(e);
		}
		isEnabled = !isEnabled;
	});
}

let enableAttorneyList = (e) => {
	e.preventDefault();
	$("#newAttorneyValue").val(false);
	$("#AttorneyListInput").show();
	$("#AttorneyInfoInput").hide();
}

let enableAttorneyInfo = (e) => {
	e.preventDefault();
	$("#newAttorneyValue").val(true);
	$("#AttorneyListInput").hide();
	$("#AttorneyInfoInput").show();
}
$(document).ready(() => {
	manageCourt();
	manageAttorney();
	manageProsecution();
	manageDefense();
	manageRecipient();
});

//prosecution
let manageProsecution = () => {
	$('.newProsecutionButton').click((e) => {
		e.preventDefault();
		$("#newProsecutionValue").val(!$("#newProsecutionValue").val);
		$("#ProsecutionListInput").toggle();
		$("#ProsecutionInfoInput").toggle();
	});
}

//defense
let manageDefense = () => {
	$('.newDefenseButton').click((e) => {
		e.preventDefault();
		$("#newDefenseValue").val(!$("#newDefenseValue").val);
		$("#DefenseListInput").toggle();
		$("#DefenseInfoInput").toggle();
	});
}

//recipient
let manageRecipient = () => {
	$('.newRecipientButton').click((e) => {
		e.preventDefault();
		$("#newRecipientValue").val(!$("#newRecipientValue").val);
		$("#RecipientListInput").toggle();
		$("#RecipientInfoInput").toggle();
	});
}

//court
let manageCourt = () => {
	$('.newCourtButton').click((e) => {
		e.preventDefault();
		$("#newCourtValue").val(!$("#newCourtValue").val);
		$("#CourtListInput").toggle();
		$("#CourtNameInput").toggle();
	});
}

//attorney
let manageAttorney = () => {
	$('.newAttorneyButton').click((e) => {
		e.preventDefault();
		$("#newAttorneyValue").val(!$("#newAttorneyValue").val);
		$("#AttorneyListInput").toggle();
		$("#AttorneyInfoInput").toggle();
	});
}
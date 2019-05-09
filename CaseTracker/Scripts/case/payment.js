$(document).ready(() => {
	$("#submit").click(submitUserInfo);
});

let submitUserInfo = (e) => {
	e.preventDefault();

	if (!$("#proform").valid()) {
		//alert("missing");
		return;
	}

	let cardNumber = $("input[name=cardnumber]").val();
	let expiresmonth = $("select[name=expiresmonth]").val();
	let expiresyear = $("select[name=expiresyear]").val();
	let fname = $("input[name=fname]").val();
	let lname = $("input[name=lname]").val();

	$.post("/api/Payment", {
		"cardnumber": cardNumber,
		"expiresmonth": expiresmonth,
		"expiresyear": expiresyear,
		"fname": fname,
		"lname": lname
	}, proSuccess);
}

let proSuccess = () => {
	let pathArray = window.location.pathname.split("/");
	console.log(pathArray);
	let target = "/Home/Pro";
	if (pathArray[1] === "en") {
		target = "/en" + target;
	} else if (pathArray[1] === "el") {
		target = "/el" + target;
	}
	window.location.replace(target);
}
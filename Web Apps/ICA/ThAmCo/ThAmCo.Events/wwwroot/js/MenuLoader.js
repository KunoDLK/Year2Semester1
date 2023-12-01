$(document).ready(function () {

	GetMenuItemIds();
});

function GetMenuItemIds() {
	$.ajax({
		url: "https://localhost:7173/api/MenuFoodItems",
		type: "GET",
		crossDomain: true,
		success: function (result) {
			var menuId;
			for (var i = 0; i < result.length; i++) {
				menuId = result[i].menuId;
				$('Menu' + menuId).append('<li>' + result[i].foodItemId + '</li>');
			}
		}
	});
}
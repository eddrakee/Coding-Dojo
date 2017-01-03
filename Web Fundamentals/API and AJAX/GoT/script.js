$(document).ready(function(){
	$(".house").click(function(){
		var houseNum = $(this).data("num");
		console.log(houseNum);
		$.get(`http://anapioficeandfire.com/api/houses/${houseNum}`, function(houseInfo){
			console.log(houseInfo);

			var infoStr = `
			<h2>Name: </h2><p>${houseInfo.name}</p>
			<h2>Words: </h2><p>${houseInfo.words}</p>
			<h2>Title: </h2>
				<ul>`;

			for(var i =0; i<houseInfo.titles.length; i++){
				infoStr += `<li>${houseInfo.titles[i]}</li>`
			}
			
			$("#info").html(infoStr);
		})
	})



})

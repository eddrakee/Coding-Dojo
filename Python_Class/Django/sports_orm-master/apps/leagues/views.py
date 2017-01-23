from django.shortcuts import render, redirect
from django.db.models import Q #this let's us use OR
from .models import League, Team, Player

from . import team_maker

def index(request):
	context = {
		#level 1
		"leagues": League.objects.all(),
		"teams": Team.objects.all(),
		"players": Player.objects.all(),
		#answers for Level 1
		"baseball": League.objects.filter(name__contains="baseball"),
		"women": League.objects.filter(name__contains="women"),
		"hockey": League.objects.filter(name__contains="hockey"),
		"football": League.objects.exclude(name__contains="football"),
		"conference": League.objects.filter(name__contains="conference"),
		"atlantic": League.objects.filter(name__contains="atlantic"),
		"dallas": Team.objects.filter(location__contains="Dallas"),
		"raptors": Team.objects.filter(team_name__contains="raptors"),
		"city": Team.objects.filter(location__contains="city"),
		"T": Team.objects.filter(team_name__startswith="T"),
		"OrderedByLocation": Team.objects.order_by("location"),
		"ReverseTeam": Team.objects.order_by("-team_name"),
		#this one can also be done with Team.objects.order_by("team_name").reverse()
		"Cooper": Player.objects.filter(last_name__contains="Cooper"),
		"Joshua": Player.objects.filter(first_name__contains="Joshua"),
		"CooperNoJoshua": Player.objects.filter(last_name__contains="Cooper").exclude(first_name="Joshua"),
		"AlexORWyatt": Player.objects.filter(Q(first_name="Alexander")| Q(first_name="Wyatt")),

		#level 2
		"TeamsInAtlantic": Team.objects.filter(league__name__contains="Atlantic Soccer Conference"),
		"Penguins": Player.objects.filter(curr_team__team_name__contains="Penguins"),
		"IntlCollegiate": Player.objects.filter(curr_team__league__name__contains="International Collegiate Baseball Conference"),
		"Lopez": Player.objects.filter(curr_team__league__name__contains="American Conference of Amateur Football", last_name__contains="Lopez"),
		#Another way we can do this one is by using Q to say "and"
		"Lopez2": Player.objects.filter (Q(curr_team__league__name__contains="American Conference of Amateur Football") & Q( last_name__contains="Lopez")),
		"Football2": Player.objects.filter(curr_team__league__sport__contains="football"),
		"Sophia1": Team.objects.all().filter(curr_players__first_name__contains="Sophia")
	
}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")


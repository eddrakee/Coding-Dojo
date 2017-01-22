from django.shortcuts import render, redirect, HttpResponse
from random import randint

# Create your views here.
def index(request):
    print "a"
    if not 'money' in request.session:
        request.session['money'] = 0
    if not 'activity' in request.session:
        request.session['activity'] = []
    return render(request, "gold/index.html")

def findGold(request):
    places = {
        'farm': randint(-20,5),
        'casino': randint(-50,50),
        'cave': randint(0,30),
        'house': randint(0,5)
    }

    if request.method == 'POST':
        if request.POST['place'] in places: #if the name in our html form is in our places dictionary do the following:
            result = places[request.POST['place']] # set places key where key = request.POST['place']
            request.session['money'] = request.session['money']+result #update our money with the new money we found at this place
            if int(result) > 0: #we have to make result an integar since it is a string and needs to be compared to an integer
                winning_dictionary = {
                    'outcome': 'You visited the {} and {} {} gold!'.format(request.POST['place'], ('gained'), result)
                   }
                    #('gained') is in parantheses because it is a string
                    #we use .format as a way to use the {} as holders
                request.session['activity'].append(winning_dictionary) 
            #this elif is for when we lose money
            elif int(result) < 0:
                losing_dictionary = {
                    'outcome': 'You visited the {} and {} {} gold!'.format(request.POST['place'], ('lost'), result)
                   }
                
                request.session['activity'].append(losing_dictionary)
        return redirect('/')

def reset(request):
    del request.session['money']
    del request.session['activity']
    return redirect ('/')
from django.shortcuts import render,HttpResponse, redirect

# Create your views here.
def index(request):
    print "a"
    return render(request, "survey/index.html")

def formSubmit(request):
   
    #     request.session["name"] = request.POST["name"]

    if request.method == "POST":
        request.session["name"] = request.POST["name"]
        request.session["location"] = request.POST["location"]
        request.session["snacks"] = request.POST["snacks"]
        request.session["comment"] = request.POST["comment"]
        print request.session["name"]
        print request.session["location"]
        print request.session["snacks"]
        print request.session["comment"]
        return redirect("/result")
    else:
        return redirect("/")

def showResults(request):

    return render(request, "survey/userAnswer.html")

def reset(request):
    return redirect (request, "survey/index.html")

#if we do 
#   if not request.session ["name"] = request.POST["name"] 
# 
# underneath the "if request.method =="POST"
#  it will save the session. 
#we don't want this for this assignment, but for things like Login and you want to remain logged in
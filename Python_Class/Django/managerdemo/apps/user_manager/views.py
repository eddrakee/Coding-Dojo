from django.shortcuts import render, HttpResponse, redirect
from .models import User
# Create your views here.
def index(request):
    #at one point i had too few positional arguments for this and now i have enough! yay!!
    #user property is an instance of our user manager class. user manager can use all manager properties
    #it allows us to make customized queries. pretty cool. Kargs-keyWord arguments
    context={
        'all_users': User.objects.all()
    }
    return render(request, 'user_manager/index.html', context)

def create_user(request):
    if request.method=='POST':
        # request.POST == a dictionary
        print (request.POST, "in create user, expect next thing to be in User.objects")
        User.objects.register(request.POST)
        #.register refers to the class method in userManager called register
        # postData= User.objects.login(request.POST['password'], request.POST['first_name'], request.POST['last_name'])
        return redirect('/')

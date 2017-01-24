from django.shortcuts import render, HttpResponse, redirect
from .models import User
# Create your views here.
def index(request):
    #Make sure to have enough positional arguments!
    #The user property is an instance of our UserManager class.
    #UserManager can use all the manager properties and allows us to make customized queries.
    #Kwargs = Key Word Arguments 
    
    context={
        'all_users': User.objects.all()
    }
    return render(request, 'user_manager/index.html', context)

def create_user(request):
    if request.method=='POST':
        # request.POST is a dictionary
        #this refers back to the class UserManager>def register>postData
        print (request.POST, "in create user, expect next thing to be in User.objects")
        User.objects.register(request.POST)
        #.register refers to the class method in userManager called register
        # postData = User.objects.login(request.POST['password'], request.POST['first_name'], request.POST['last_name'])
        return redirect('/')

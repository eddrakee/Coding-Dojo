#THIS IS OUR CONTROLLER!!!

# from django.shortcuts import render, HttpResponse
# # Create your views here.

# def index(request):
#     response = "Hello, I am your first request!"
#     return HttpResponse(response)

# While Django will automatically creates the request object for us that's passed into our method, 
# HttpResponse objects are our responsibility to create and return to the browser. 
# Note that 'render' is a shortcut method that combines a given template with a given 
# context dictionary and returns an HttpResponse object with that rendered text. 
# We are not using render because we haven't created any templates yet!

from django.shortcuts import render

def index(request):
    print ("*"*100)
    return render(request, "first_app/index.html")

def show(request):
    print (request.method)
    return render(request, "first_app/show_users.html")
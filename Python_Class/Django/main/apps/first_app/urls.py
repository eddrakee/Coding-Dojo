# from django.conf.urls import url #we added include. it will let us include stuff from the apps folder

# def index(request):
#   print("banana")
# urlpatterns = [
#       url(r'^$', index) 
#   ]

# #r'^$' = nothing. Essentially, when this ran, it said if you find nothing, do the index function which said to print "banana" in the terminal
# #this shows you how it all connects

# from django.conf.urls import url
# def method_to_run(request):
#     print "Whatever route that was hit by an HTTP request (by the way) decided to invoke me!"
#     print "By the way, here's the request object that Django automatically passes us:", request
#     print "By the by, we still aren't delivering anything to the browser, so you should see 'ValueError at /'"
# urlpatterns = [
#     url(r'^$', method_to_run)
# ]

#the code above technically isn't a method since it is not attached to an object


#modularized code. now the function we invoke doesn't live in this file
# from django.conf.urls import url #this gives us access to the variable url (which points to a function)
# from . import views #this gives us access to everythig in a views.py file that Django automatically built when first_app was created
# urlpatterns = [
#   url(r'^$', views.index) 
#]
#the line above uses the url method in a similar way to @app.route. the "r" after the "(" identifies the following string to match as a regular expression pattern.
#in this case, it will exaclty match an empty string. That means if you were to go to localhost:8000/, Django (after removing the '/' automatically) will check if anything matches.
#and it does! an empy string is what r'^$' looks for. Since the pattern matches, we look for the views.index method
#url() will eventually take another parameter, something like name="index" which we will discuss in named routes

#also, Django doesn't care if it's a GET or POST method. That can be accessed in the request.method in our function

from django.conf.urls import url
from . import views

urlpatterns = [
  url(r'^$', views.index),
  url(r'^users$', views.show)
]
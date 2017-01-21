from django.shortcuts import render
from datetime import datetime
# Create your views here.
def findDate(request):
    #code below is the initial attempt. It works but does not display the time as well as the date
    # data = {'current_date' : datetime.now()} 
    # return render(request, "index.html", data)


    i = datetime.now()
    dateTime = ("%s/%s/%s" % (i.day,i.month,i.year)) + (" %s:%s:%s" % (i.hour,i.month,i.second))
    
    data={
    "current_date":dateTime
    }
    return render(request, "index.html", data) #this is like a render_template function in flask
    #render will accept 3 parameters: request, the html file and the dictionary
from django.shortcuts import render

# Create your views here.
def index(request):
    print "hello"
    return render(request, "disappearNinjas/noTurtles.html")

def showAll(request):
    print "bob"
    return render(request, "disappearNinjas/index.html")


def show(request, color):
    print "goodbye"
    option = {
        'red': 'disappearNinjas/images/tmnt_red.jpg',
        'blue': 'disappearNinjas/images/tmnt_blue.jpeg',
        'orange': 'disappearNinjas/images/tmnt_orange.jpg',
        'purple': 'disappearNinjas/images/tmnt_purple.jpg'
    }
    if color in option:
        context = {
            'image':option[color]
        }
    else:
        context = {
            'image': 'disappearNinjas/images/pizza_time.jpg'
        }
    return render(request, 'disappearNinjas/index.html', context)






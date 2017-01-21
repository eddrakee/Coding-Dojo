from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.findDate),
]
#make sure to go to views and put in the function findDate. That is what the line above is calling to
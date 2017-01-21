from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^surveys/process$', views.formSubmit),
    url(r'^result$', views.showResults) #this is not our index.html, but our first method which is called index
]
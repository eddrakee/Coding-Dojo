from django.conf.urls import url
from . import views #.=current directory!

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register$', views.create_user)
]
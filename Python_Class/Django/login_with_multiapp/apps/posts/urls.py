from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.wall, name='the_wall'),
]
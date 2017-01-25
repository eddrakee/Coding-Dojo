from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.index), 
    # we will use "name" later on when we are going between apps
    url(r'^register$', views.register),
    url(r'^login$', views.login),
    url(r'^success$', views.success),
    url(r'^logout$', views.logout),
]

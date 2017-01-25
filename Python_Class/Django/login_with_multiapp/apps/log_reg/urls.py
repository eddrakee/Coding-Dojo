from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.index, name='index'), 
    # we will use "name" later on when we are going between apps
    url(r'^register$', views.register, name='registered'),
    url(r'^login$', views.login, name='log_in'),
    url(r'^success$', views.success, name='login_success'),
    url(r'^logout$', views.logout, name='log_out'),
]

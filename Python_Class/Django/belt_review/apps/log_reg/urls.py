from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.index, name="log_index"), 
    # we will use "name" later on when we are going between apps
    url(r'^register$', views.register, name="registered"),
    url(r'^login$', views.login, name="logged_in"),
    url(r'^success$', views.success, name="login_success"),
    url(r'^logout$', views.logout, name ="logged_out"),
]


# first app namespace = login_ns
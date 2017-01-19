#Now, create another class called Dragon that also inherits everything from Animal, but 1) have the default health be 170 and 2) add a new method called fly, which when invoked, decreased the health by 10. Have the Dragon walk() three times, run() twice, fly() twice, and have it displayHealth(). When the Dragon's displayHealth function is called, have it say 'this is a dragon!' before it displays the default information (by calling the parent's displayHealth function).

from animal import Animal #from folder, import file

class Dragon(Animal):
    def __init__(self,name):
        super(Dragon, self).__init__(name) #you don't need to put self next to name since it is already being passed in from the functions in Animal
        self.health = 170
    def fly(self):
        self.health -= 10
        return self
    def displayHealth(self):
        print "This is a dragon. Rawrr!"
        super(Dragon, self).displayHealth()
        return self

Dragon1 = Dragon('blackDragon')
print "- From Dragon File -"
Dragon1.walk().walk().walk().run().run().fly().fly().displayHealth()

#Create a class called Animal with the following attributes: name, and health. Give the animal following three methods: walk, run, and displayHealth. Give a new animal a health of 100 when it gets created. When a walk() method is invoked, have the health decrease by 1. When a run() method is invoked, have the health decrease by 5. When a displayHealth() method is invoked, display on screen the name of the Animal and the health.

class Animal(object):

    def __init__(self, name, health=100):
        self.name = name
        self.health = health
    def walk(self):
        self.health -= 1
        return self

    def run(self):
        self.health -= 5
        if self.health <=20:
            print "Rest your self! Health is low!"
        elif self.health == 0:
            print "You are now dead."
        return self

    def displayHealth(self):
        print "Name:", str(self.name)
        print "Health:", str(self.health)
        return self

#Create an instance of the animal called 'animal' and have this animal walk three times, run twice, and have it display its health.

animal1 = Animal("Zebra")
print "- From Animal File -"
animal1.walk().walk().walk().run().run().displayHealth()

#Now, create another class called Dog that inherits everything that the Animal does and has, but 1) have the default health be 150 and 2) add a new method called pet, which when invoked, increase the health by 5. Have the Dog walk() three times, run() twice, pet() once, and have it displayHealth().

#SEE DOG.PY

#Now, create another class called Dragon that also inherits everything from Animal, but 1) have the default health be 170 and 2) add a new method called fly, which when invoked, decreased the health by 10. Have the Dragon walk() three times, run() twice, fly() twice, and have it displayHealth(). When the Dragon's displayHealth function is called, have it say 'this is a dragon!' before it displays the default information (by calling the parent's displayHealth function).

#SEE DRAGON.PY

#Now for the first instance of the animal (instance called 'animal'), try calling fly() or pet() and make sure this doesn't work.  (-:
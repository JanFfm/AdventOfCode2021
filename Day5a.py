import numpy as np

class vent:
    def __init__(self, p1, p2):
        self.p1 = p1
        self.p2 = p2
    def show_points(self):
        print (self.p1, self.p2)
class vent_map:
    def __init__(self):
        self.map = np.array([[0 for i in range(10)] for j in range(10)])
        print(self.map)

input_file = open('example5.txt', 'r')
vents = []

v_map = vent_map()

for l in input_file:
    l = l.split('\n')[0]
    
    l = l.split(" -> ")
    l = [l[0].split(','), l[1].split(',')]
    v = vent(l[0], l[1])
    vents.append(v)






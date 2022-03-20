from typing_extensions import Self


class submarine:
    horizontal_position = 0
    depth = 0

    def up(self, x):
         self.depth -=x
    def down(self, x):
         self.depth +=x
   
    def forward(self, x):
         self.horizontal_position +=x
    
    def get_input(self, s: str):
        comand = s.split(' ')[0]
        value = int(s.split(' ')[1])
        if comand == "up":
            self.up(value)
        if comand == "down":
            self.down(value)
        if comand == "forward":
            self.forward(value)


sub =submarine()
input_file = open('input2a.txt', 'r')
for l in input_file:
    sub.get_input(l.split('\n')[0])
print("depth ", sub.depth)
print("horizontal position ", sub.horizontal_position)
print("multiplied=",sub.depth*sub.horizontal_position)
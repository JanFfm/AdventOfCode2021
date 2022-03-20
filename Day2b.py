

class submarine:
    horizontal_position = 0
    depth = 0
    aim = 0

    def up(self, x):
        self.aim -=x
    def down(self, x):
        self.aim +=x
   
    def forward(self, x):
         self.horizontal_position +=x
         self.depth += x * self.aim
    
    def get_input(self, s: str):
        comand = s.split(' ')[0]
        value = int(s.split(' ')[1])
        if comand == "up":
            self.up(value)
        elif comand == "down":
            self.down(value)
        elif comand == "forward":
            self.forward(value)


sub =submarine()

input_file = open('input2.txt', 'r')
for l in input_file:
    sub.get_input(l.split('\n')[0])
print("depth ", sub.depth)
print("horizontal position ", sub.horizontal_position)
print("multiplied=",sub.depth*sub.horizontal_position)

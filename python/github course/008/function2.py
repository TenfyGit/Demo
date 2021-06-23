from random import randint
# 定义摇色子的函数，n表示色子的个数，默认值为2
def roll_dice(n=2):
    total = 0
    for _ in range(n):
        total += randint(1,6)
    return total
print(roll_dice())
print(roll_dice(3))
import random
# 产生一个1-100范围的随机数
answer = random.randint(1,100)
print(answer)
counter = 0
while True:
    counter += 1
    number = int(input('请输入：'))
    if number < answer:
        print('大一点')
    elif number > answer:
        print('小一点')
    else:
        print('恭喜你猜对了')
        break
print(f'你总共猜了{counter}次')
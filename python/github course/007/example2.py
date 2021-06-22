# 正整数的反转
num = int(input('num = '))
reversed_num = 0
while num > 0:
    print(f'运算前 reversed_num:{reversed_num} num:{num}')
    reversed_num = reversed_num * 10 + num % 10
    num //= 10
    print(f'运算后 reversed_num:{reversed_num} num:{num}')
print(reversed_num)
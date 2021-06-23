# 可变参数
# 用星号表达式来表示args可以接收0个或任意多个参数
def add(*args):
    total = 0
    for val in args:
        total += val
    return total
print(add())
print(add(1))
print(add(1,2))
print(add(1,2,3))
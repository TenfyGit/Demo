# 查找操作
s = 'hello,world!'
# find与index都可以用来从字符串中查找另一字符串所在的位置，如果找不到的话，find返回-1，而index报异常
print(s.find('or'))
print(s.find('shit'))
print(s.index('or'))
# print(s.index('shit')) 报异常

# 通过方法参数来指定查找范围
s = 'hello good world!'
# 查找第一次出现o的位置
print(s.find('o'))
# 从索引为5的位置开始查找o出现的位置
print(s.find('o',5))
# 从后向前查找o出现的位置
print(s.rfind('o'))
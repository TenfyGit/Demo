# 格式化字符串
s = 'hello,world'
# center方法以宽度20将字符串居中并在两侧填充指定字符
print(s.center(20,'*'))
# rjust方法以宽度20将字符串右对齐并在左侧填充空格
print(s.rjust(20))
# ljust方法以宽度20将字符串左对齐并在右侧填充
print(s.ljust(20,'~'))

a = 321
b = 123
print('{0} * {1} = {2}'.format(a,b,a*b))

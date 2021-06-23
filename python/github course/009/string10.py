# 性质判断
s1 = 'hello,world!'
# 判断字符串是否以指定字符串开头
print(s1.startswith('He'))
print(s1.startswith('hel'))
# 判断字符串是否以指定字符串结尾
print(s1.endswith('!'))

s2 = 'abc123456'
# 判断字符串是否由数字组成
print(s2.isdigit())
# 判断字符串是否由字母组成
print(s2.isalpha())
# 判断字符串是否由数字和字母组成
print(s2.isalnum())
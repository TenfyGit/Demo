s1 = 'hello world'
s2 = 'hello world'
s3 = s2
# ==比较的是字符串的内容
print(s1 == s2,s2 == s3)
# is比较的是字符串的内存地址
print(s1 is s2,s2 is s3,s1 is s3)
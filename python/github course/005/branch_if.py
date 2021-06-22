# if语句
"""
python使用了缩进的方式来表示代码的层次结构
连续的代码如果又保持了相同的缩进那么它们属于同一个代码块
"""
username = input('请输入用户名：')
password = input('请输入口令：')
if username == 'admin' and password == '123456':
    print('身份验证成功!')
else:
    print('身份验证失败！')

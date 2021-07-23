import random

all_chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"

def generate_code(code_len = 4):
    """生成指定长度的验证码
    :param code_len:验证码的长度(默认4个字符)
    :return:由大小写英文字母和数字构成的随机验证码字符串
    """
    code = ''
    for _ in range(code_len):
        # 产生0到字符串长度减1范围的随机数作为索引
        index = random.randrange(0,len(all_chars))
        # 利用索引运算从字符串中取出字符并进行拼接
        code += all_chars[index]
    return code
def generate_code2(code_len = 4):
    """生成指定长度的验证码
    :param code_len:验证码的长度(默认4个字符)
    :return:由大小写英文字母和数字构成的随机验证码字符串
    """
    return ''.join(random.choices(all_chars,k=code_len)) #有放回抽样
def generate_code3(code_len = 4):
    """生成指定长度的验证码
    :param code_len:验证码的长度(默认4个字符)
    :return:由大小写英文字母和数字构成的随机验证码字符串
    """
    return ''.join(random.sample(all_chars,k=code_len)) #有放回抽样
for _ in range(10):
    print(generate_code3())
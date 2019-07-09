'''Questão 1 : faça um algorítimo que transforma uma expressão infixa com parênteses em uma expressão posfixa '''


def precedencia(op1,op2):
    #retorna True se op1 tem precedencia sobre op2
    if op1 =='^':
        return true
    if op1 in "*/" and op2 in "+-":
        return True
    return False


def lerInfixPosFix(string):
    #pilha para armazenar operadores
    pilhaOperador=[]
    saida=""
    operadores="+-*/^()"
    
    for letra in string:

        #se é um operador salvamos na pilha.
        if letra in operadores:
            if letra=="(":
                pilhaOperador.append(letra)

            #se é um fecha parenteses, devemos dar um flush na pilha, até encontrar o último abre parenteses.
            elif letra==")":
                while pilhaOperador[-1]!='(':
                    saida+=pilhaOperador.pop()
                pilhaOperador.pop()


            else:                
                #se o caractere no topo da pilha tem precedencia sobre letra, devemos tira-lo da pilha
                if len(pilhaOperador)!=0:
                    while precedencia(pilhaOperador[-1],letra):
                        saida+=pilhaOperador.pop()
                pilhaOperador.append(letra)
                
        else:
            saida+=letra

        #apenas para mostrar os estados da pilha e da saida a cada instante
        print (letra,pilhaOperador,saida)
        
    #no final da execução ainda restam alguns operadores na pilha. Vamos removê-los 
    while len(pilhaOperador)!=0:
         saida+=pilhaOperador.pop()

    return saida


print (lerInfixPosFix("a+b^(d*c+e)"))    


'''Questão 2 : GRID. '''
class computador:
    def __init__(self,ip,conhecidos):
        self.ip
        self.conhecidos=conhecidos

#grid conhece todos os 
grid = computador(25,[0])







''' questao 3 dada uma arvore na forma pre e na forma simétrica:
pre      : A B D G C E H I F
simétrica: D G B A H E I C F
'''






        

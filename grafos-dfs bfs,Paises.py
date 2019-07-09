#busca em profundidade

BRANCO=1
PRETO=2
CINZA=3
CAMINHO=""

class vertice:
    def __init__(self,dado):
        self.dado=dado
        self.cor=BRANCO
        self.distancia=1000000000
        self.pai=0
        self.D=0
        self.F=0
    def setarFilho(self,listaFilhos,custo=[]):
        self.filhos=listaFilhos
        self.custo=custo
    
    def show(self):
        cor=[0,"branco","preto","cinza"]
        print("dado: %s , distância:%s , cor:%s , D/F:%i/%i"%(self.dado,self.distancia,cor[self.cor],self.D,self.F))
        

#philadelfia=vertice("philadelfia")
#boston=vertice("boston")
#ny=vertice("ny")
#washintong=vertice("washintong")
#brasil=vertice("brasil")





#philadelfia.setarFilho([ny,boston,washintong],[60,400,150])
#ny.setarFilho([philadelfia,washintong,boston],[60,120,200])
#boston.setarFilho([ny,philadelfia,washintong],[200,400,100])
#washintong.setarFilho([philadelfia,ny,boston,brasil],[150,120,100.1000])
#brasil.setarFilho([ny],2000)

#grafo=[philadelfia,ny,boston,washintong,brasil]


#u=vertice("u")
#v=vertice("v")
#w=vertice("w")
#x=vertice("x")
#y=vertice("y")
#z=vertice("z")


#u.setarFilho([v,x])
#v.setarFilho([y])
#w.setarFilho([y,z])
#x.setarFilho([y])
#y.setarFilho([x])
#z.setarFilho([z])

#grafo=[u,v,w,x,y,z]


argentina=vertice("argentina")
uruguai=vertice("uruguai")
bolivia=vertice("bolivia")
paraguai=vertice("paraguai")
chile=vertice("chile")
peru=vertice("peru")
brasil=vertice("brasil")
equador=vertice("equador")
colombia=vertice("colombia")
venezuela=vertice("venezuela")
guiana=vertice("guiana")
suriname=vertice("suriname")
guianaFrancesa=vertice("guianaFrancesa")


argentina.setarFilho([uruguai,brasil,paraguai,bolivia,chile])
uruguai.setarFilho([argentina,brasil])
bolivia.setarFilho([argentina,paraguai,brasil,chile,peru])
paraguai.setarFilho([argentina,brasil,bolivia])
chile.setarFilho([argentina,bolivia,peru])
peru.setarFilho([bolivia,chile,equador,brasil,colombia])
brasil.setarFilho([uruguai,paraguai,argentina,bolivia,peru,colombia,venezuela,guiana,guianaFrancesa])
equador.setarFilho([peru,colombia])
colombia.setarFilho([peru,equador,brasil,venezuela])
venezuela.setarFilho([colombia,brasil,guiana])
guiana.setarFilho([venezuela,brasil,suriname])
suriname.setarFilho([brasil,guiana,guianaFrancesa])
guianaFrancesa.setarFilho([brasil,suriname])



grafo=[argentina,uruguai,bolivia,paraguai,chile,peru,brasil,equador,colombia,venezuela,guiana,suriname,guianaFrancesa]



#obtem o menor caminho até todos os vertices acessiveis 
def buscaExtensao(grafo,primeiro):
    primeiro.cor=CINZA
    primeiro.distancia=0
    filaCinza=[]
    filaCinza.append(primeiro)
    
    while len(filaCinza)!=0:
        atual= filaCinza.pop()
        listaV=atual.filhos
        for vertice in listaV:
            if vertice.cor==BRANCO:
                vertice.cor=CINZA
                vertice.distancia = atual.distancia+1
                vertice.pai=atual
                filaCinza.append(vertice)
        atual.cor=PRETO
        
def DFP_Visita(vertice,tempo):
    global CAMINHO
    vertice.cor=CINZA
    tempo+=1
    vertice.D=tempo
    CAMINHO+="->"+vertice.dado
    for filho in vertice.filhos:
        if filho.cor==BRANCO:
            filho.pai=vertice
            tempo=DFP_Visita(filho,tempo)
    vertice.cor=PRETO
    tempo+=1
    vertice.F=tempo
    return tempo

def DFS(grafo):
    
    tempo=0
    for vertice in grafo:
        if vertice.cor==BRANCO:
            tempo=DFP_Visita(vertice,tempo)
            


#buscaExtensao(grafo,philadelfia)
DFS(grafo)
for i in grafo:
    i.show()



print (CAMINHO)






























                

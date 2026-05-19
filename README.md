# Museu da Astronomia

**Autor:** Patrício Alves  
**Trilha:** SmartContracts  

## Descrição do Projeto

O **Museu da Astronomia** é um projeto desenvolvido na Unity com o objetivo de demonstrar um ambiente 3D interativo voltado à apreciação, exploração e aprendizado da Astronomia por jovens.

A proposta é criar uma experiência visual, educativa e imersiva, em que o usuário possa explorar um ambiente virtual temático e interagir com objetos astronômicos, tornando o aprendizado mais dinâmico e acessível.

## Objetivo

O principal objetivo do projeto é apresentar uma aplicação interativa em 3D que desperte o interesse dos jovens pela Astronomia, utilizando recursos visuais, modelos tridimensionais, áudio explicativo e elementos temáticos relacionados ao espaço.

Além da composição visual do ambiente, o projeto inclui uma interação funcional implementada em C#, atendendo ao requisito de interatividade do ambiente virtual.

## Conceito da Aplicação

O ambiente foi pensado como uma espécie de museu virtual de Astronomia.

No cenário, há planetas posicionados como objetos de exposição, além de elementos que reforçam a temática espacial, como telescópio, suporte de exibição e ambientação visual relacionada ao espaço.

A ideia é permitir que o usuário visualize e interaja com objetos astronômicos em um ambiente tridimensional, criando uma experiência semelhante à visitação de uma exposição científica virtual.

## Elementos do Projeto

O projeto contém os seguintes elementos principais:

- Ambiente 3D interativo;
- Modelos tridimensionais relacionados à Astronomia;
- Planetas posicionados no ambiente do museu;
- Telescópio como elemento temático de observação astronômica;
- Suporte para exposição dos objetos;
- Iluminação e ambientação visual;
- Áudios explicativos associados aos planetas;
- Script de interação implementado em C#;
- Proposta educativa voltada ao público jovem.

## Interação Implementada

Foi implementada uma interação funcional em C# aplicada aos planetas do museu.

A interação permite que o usuário selecione um planeta no ambiente. Ao interagir com o objeto, o planeta aumenta levemente de tamanho e reproduz um áudio explicativo com informações sobre o corpo celeste selecionado.

Essa funcionalidade torna o ambiente mais educativo e interativo, simulando uma experiência de visitação em um museu virtual, na qual o visitante pode obter informações sobre os objetos expostos.

## Funcionamento da Interação

A interação ocorre por meio de um sistema de seleção com Raycast.

Quando o usuário aponta ou seleciona um planeta, o sistema identifica o objeto atingido. Ao realizar a interação, o objeto executa duas ações principais:

- Aumento temporário da escala do planeta;
- Reprodução de áudio explicativo associado ao planeta.

Também foi implementado destaque visual para indicar o objeto selecionado no ambiente.

## Exemplos de Áudios

### Marte

Marte é o quarto planeta do Sistema Solar. É conhecido como planeta vermelho devido à presença de óxidos de ferro em sua superfície.

### Mercúrio

Mercúrio é o planeta mais próximo do Sol e o menor planeta do Sistema Solar. Sua superfície é rochosa e cheia de crateras, parecida com a superfície da Lua. Por estar muito perto do Sol, apresenta grandes variações de temperatura entre o dia e a noite.

### Saturno

Saturno é o sexto planeta do Sistema Solar e é conhecido por seus impressionantes anéis. Esses anéis são formados por partículas de gelo, poeira e fragmentos rochosos. Saturno é um planeta gasoso, composto principalmente por hidrogênio e hélio, e possui muitas luas ao seu redor.

## Scripts Principais

### SistemaSelecaoAudioEscala.cs

Script responsável por detectar a seleção do objeto no ambiente, aplicar destaque visual, aumentar a escala do planeta e reproduzir o áudio associado ao objeto selecionado.


## Áudios

Os arquivos de áudio foram adicionados à pasta:

Assets/Audio

Exemplos de arquivos utilizados:

- audio_marte.wav
- audio_mercurio.wav
- audio_saturno.wav

Cada planeta interativo possui um componente Audio Source com o respectivo áudio associado.

## Tecnologias Utilizadas

- Unity;
- C#;
- Meta XR Simulator;
- Meta XR SDK;
- Modelos 3D;
- Sistema de Raycast;
- Componentes Audio Source;
- Git e GitHub;
- Conceitos de ambientes virtuais interativos;
- Conceitos da trilha SmartContracts aplicados ao contexto do projeto.

## Público-Alvo

O projeto foi pensado principalmente para jovens estudantes interessados em Astronomia, tecnologia, ambientes virtuais e experiências interativas de aprendizagem.

## Possíveis Aplicações

Este projeto pode ser utilizado como base para:

- Museu virtual de Astronomia;
- Ambiente educacional interativo;
- Exposição digital de planetas e objetos astronômicos;
- Projeto introdutório de metaverso educacional;
- Demonstração de ambientes 3D aplicados ao ensino;
- Protótipo de experiência imersiva com interação em objetos virtuais.

## Como Executar o Projeto

1. Abrir o projeto pela Unity Hub.
2. Carregar a cena principal do Museu da Astronomia.
3. Executar a cena no modo Play.
4. Utilizar a janela Game ou o Meta XR Simulator para navegar no ambiente.
5. Se aproximar e Selecionar os planetas interativos.
6. Observar o aumento de escala do planeta e ouvir o áudio explicativo.

Obs: a iteração com o mouse é prejudicada no ambiente do Meta XR Simulator. Assim usar o modo Game do Unity para testar a interação com os planetas.

## Controle de Versão

O projeto está versionado com Git e hospedado no GitHub no repositório:

projeto-metaverso-museu-astronomia

## Objetivo Educacional

O projeto demonstra o uso de ambientes virtuais interativos como recurso didático para apresentação de conteúdos de Astronomia.

A interação com os planetas permite associar elementos visuais, áudio e resposta do objeto, tornando a experiência mais dinâmica, acessível e adequada ao contexto de um museu virtual educativo.
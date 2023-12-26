# Ocelot Gateway

O Ocelot é um recurso que nós permite agrupar microserviços de forma que não é necessário manter a URL de cada serviço em vários locais. Ele funciona como um proxy redirecionando 
a solicitação para o serviço adequado, além de possibilitar a utilização de balanço de carga com proxy reverso.

Nesse simples projeto o serviço 2 consome o serviço 1 e obtém uma pequena listagem de pessoas onde cada uma delas tem:

```json
  {
    "Name": "Gabriel",
    "Age": 23,
    "Number": "14725"
  }
````

Ao receber esse objeto o serviço 2 aplica uma máscara para a propriedade "Number". Obs: o código abaixo foi feito 100% por mim sem ajuda de ChatGPT ou algo do tipo então provavelmente
necessite de uma avaliação mais rigorosa, por exemplo, se o Number for maior > 5 é certeza que vai gerar uma execeção.

```cs
   public static string ApplyMask(string value)
    {
        char[] mask = { '0', '0', '0', '0', '-', '0' };

        value = new string(value.Trim().Where(char.IsDigit).ToArray());

        char last = value[^1];

        int diff = mask.Length - value.Length;
        int currentIndex = diff == mask.Length - 1 ? mask.Length - 1 : diff - 1;
        string newValue = value.Substring(0, value.Length - 1);

        if (!string.IsNullOrEmpty(newValue))
        {
            char[] split = new string(newValue.Reverse().ToArray()).ToCharArray();
            int splitIndex = 0;

            // Gambiarra do Biel
            for (int i = currentIndex + 1; i < mask.Length; i++)
            {
                if (split.Length <= splitIndex)
                    break;

                if (mask[i] == '-')
                {
                    mask[i + 1] = split[splitIndex];
                }
                else
                {
                    mask[i] = split[splitIndex];
                }
                splitIndex++;
            }
        }

        mask[currentIndex] = last;

        return new string(mask);
    }
````

Ao aplicar a máscara os objetos pessoa terão o seguinte formato

```json
  {
    "Name": "Gabriel",
    "Age": 23, 
    "Number": "5274-1"
  }
```

Após isso o MaskController atráves do verbo GET retorna a listagem de pessoas com essas alterações

![image](https://github.com/GNobroga/OcelotGateway/assets/88632109/218d1ffe-331f-452e-9ce6-36b0bd7e18df)

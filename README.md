Grafové algoritmy pro hledání nejkratší cesty
---

## 1. Úvod do grafů

### 🔹 Definice grafu
Graf G = (V, E), kde:
- V – množina vrcholů
- E – množina hran

**Typy grafů:**
- **Orientovaný graf**: hrany mají směr (např. A → B)
- **Neorientovaný graf**: hrany nemají směr (např. {A, B})
- **Ohodnocený graf**: každá hrana má váhu (např. vzdálenost, cena)

### 🔹 Kostra grafu
- **Minimální kostra (Spanning Tree)**: podmnožina hran, která spojuje všechny vrcholy bez cyklů s minimálním součtem vah

### 🔹 Matice sousednosti vs. seznam sousedů
- **Matice sousednosti**: 2D pole V×V, kde A[i][j] je váha hrany (i → j)
- **Seznam sousedů**: pro každý vrchol je uložen seznam sousedních vrcholů a jejich vah
  - Efektivnější u řídkých grafů

### 🔹 Reálné příklady využití
- Navigace (např. GPS, Google Maps)
- Počítačové sítě (optimalizace datových toků)
- Plánování a logistika (např. rozvoz zboží)
- Sociální sítě (vzdálenost mezi uživateli)

---

## 2. Problém hledání nejkratší cesty

### ❓ Co znamená „nejkratší cesta“
- Nejmenší možný **součet vah** na cestě mezi dvěma vrcholy

### ⚠️ Negativní hrany
- Hrany s **váhou < 0**
- **Dijkstra** s nimi nefunguje správně
- Pokud graf obsahuje **záporný cyklus**, lze opakovaně zkracovat cestu → algoritmus to musí detekovat

---

## 3. Přehled algoritmů

### 🔸 a) Dijkstrův algoritmus
- **Princip**: greedy přístup, prioritní fronta
- Vybírá vrchol s nejnižší známou vzdáleností
- **Nevýhoda**: nefunguje s negativními hranami
- **Časová složitost**: O((V + E) log V) (s prioritní frontou)

### 🔸 b) Bellman-Fordův algoritmus
- **Princip**: opakovaná relaxace všech hran (až V−1 iterací)
- **Výhoda**: funguje i s negativními hranami
- Detekuje **záporné cykly**
- **Časová složitost**: O(V · E)

### 🔸 c) Floyd-Warshallův algoritmus
- **Princip**: dynamické programování
- Iteruje přes všechny trojice vrcholů (i, j, k)
- **Vhodné pro**: hledání všech nejkratších cest mezi všemi páry vrcholů
- **Časová složitost**: O(V³)

---

## 4. Implementace (praktická část)

### 🔧 Použitý algoritmus: Bellman-Ford  
- Jazyk: **C#**
- Umístění kódu: [Program.cs](./Program.cs)

### 📥 Vstup
Graf je zadán jako seznam hran ve formátu:  
(u, v, w) → hrana z vrcholu u do v s vahou w

Příklad:
4
0 1 4
0 2 5
1 2 -2
2 3 3

### 📤 Výstup
Nejkratší vzdálenosti z počátečního vrcholu
Hlásí, pokud graf obsahuje záporný cyklus

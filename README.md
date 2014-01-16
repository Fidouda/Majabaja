Majabaja
========

Repository for our GCA4 game team :
Julien Aymong ( **Git Master (First Time)** )
Benjamin Brodeur Mathieu
Marie-France Miousse
Jérôme Daigle

#GAME_NAME_HERE

###Git Workflow

1. Fork sur GitHub
2. Clone **ton repo** sur ton ordi (<code>$ git clone git@github.com:<i>tonUsername</i>/Majabaja.git</code>)
3. Ajoute **ce repo** comme remote upstream (<code>$ git remote add upstream git://github.com/Fidouda/Majabaja.git</code>)
3.1 Guide officiel de GitHub pour les étapes 1 à 3 : https://help.github.com/articles/fork-a-repo
4. Crée une branche pour la feature sur laquelle tu veux travailler (<code>$ git checkout -b nomDeLaBranche</code>). Ceci crée automatiquement une nouvelle branche et te place dessus pour travailler
5. Développe sur ta branche, et jamais sur son propre Master  *[le temps passe]*
5.1 Plus tu codes dans plusieurs fichier, plus sa risque d'être compliqué à faire le merge 
6. Fait **souvent** des commits sur la branche avec des noms clairs et indicatifs
6.1 <code>git add fichier</code>
6.2 <code>git add .</code> (pour tout ajouter les fichiers (sauf les fichiers contenu dans le .gitignore))
6.3 <code>git commit -m "Message pas trop obscure, sinon l'equipe risque de t'assassiner."</code>
7. Envoyer tes changements sur ta branche sur GitHub (<code>$ git push -u origin nomDeLaBranche</code>) (seulement requis la premiere foi)
7.1 Après la première fois, seule <code>git push</code> sera nécessaire
8. Répète les étapes 5 à 7 jusqu'à complétion de la tâche
9. Dans ton browser, sur la page de ta branche, appuie sur [Pull Request] (Voir https://help.github.com/articles/using-pull-requests)
10. Une fois le Pull Request accepté par le Git Master, mettre à jour son propre Master
10.1 <code>git checkout master</code>
10.2 <code>git fetch upstream</code>
10.3 <code>git merge upstream/master</code>
10.4 Si des changement ont été apporté et que tu veux les importer dans ta branche aussi
10.4.1 <code>git checkout nomDeLaBranche</code>
10.4.2 <code>git merge master</code>
11. ???
12. Profit!
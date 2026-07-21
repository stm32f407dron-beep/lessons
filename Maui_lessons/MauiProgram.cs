using Microsoft.Extensions.Logging;

namespace Maui_lessons
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}



/* Работа с Git в PowerShell
 * 
 * 📌 Базовые команды
git init — инициализация нового репозитория

git clone <url> — клонирование репозитория с GitHub

git status — текущее состояние (ветка, изменения, staged/unstaged)

git branch — список веток

git checkout <branch> — переключение на другую ветку

git switch <branch> — современный аналог checkout для веток

📌 Работа с изменениями
git add <file> — добавить файл в индекс

git add . — добавить все изменения

git commit -m "Сообщение" — создать коммит

git commit -am "Сообщение" — добавить все отслеживаемые файлы и закоммитить

📌 Работа с удалённым репозиторием
git remote -v — список удалённых репозиториев

git push — отправить изменения на сервер

git pull — подтянуть изменения с сервера

git fetch — получить изменения без слияния

📌 История и сравнение
git log --oneline — краткая история коммитов

git log --oneline --graph --decorate --all — история с графом веток

git diff — показать изменения в файлах

git diff --name-only — список изменённых файлов

git show <commit> — показать изменения конкретного коммита

📌 Работа с ветками
git branch <name> — создать новую ветку

git checkout -b <name> — создать и сразу переключиться

git merge <branch> — слить ветку в текущую

git rebase <branch> — переписать историю поверх другой ветки

📌 Работа с файлами
git restore <file> — откатить изменения в файле

git rm <file> — удалить файл из репозитория

git mv <old> <new> — переименовать файл

📌 Сохранение и откат
git stash — временно убрать изменения

git stash pop — вернуть изменения из stash

git reset --hard <commit> — откатить состояние до указанного коммита

git revert <commit> — создать новый коммит, отменяющий изменения     */

# GatewayTether — درگاه پایش تراکنش‌های تتر روی شبکه ترون

**GatewayTether** یک برنامهٔ ویندوزی (Windows Forms) است که کیف‌پول‌های شبکهٔ **ترون (TRON)** را به‌صورت دوره‌ای پایش می‌کند. هر وقت تراکنش جدید **USDT (TRC20)** به یک کیف‌پول برسد، آن را در پایگاه داده ثبت می‌کند و جزئیاتش را با **Webhook** به آدرسی که شما تعیین کرده‌اید می‌فرستد. با این برنامه می‌توانید بدون اجرای نود ترون، پرداخت‌های تتر را در سیستم یا فروشگاه خودتان تأیید کنید.

## نحوهٔ کار

1. کیف‌پول (آدرس ترون + آدرس Webhook) را از داخل برنامه ثبت می‌کنید.
2. یک زمان‌بند داخلی (DNTScheduler) هر **۲ دقیقه** یک‌بار اجرا می‌شود.
3. برای هر کیف‌پول فعال، لیست آخرین ۲۰ انتقال TRC20 از API رسمی **TronScan** گرفته می‌شود.
4. فقط انتقال‌های **USDT** نگه داشته می‌شوند و با آخرین `Txid` ذخیره‌شده مقایسه می‌شوند تا انتقال‌های جدید تشخیص داده شوند.
5. هر انتقال جدید در جدول `TblTransfer` ذخیره می‌شود و یک رکورد صف ارسال در `TblWebhookRequest` ساخته می‌شود.
6. درخواست‌های در انتظار، با `POST` و بدنهٔ JSON به آدرس Webhook کیف‌پول فرستاده می‌شوند.
7. اگر پاسخ سرور شما `ok` باشد، ارسال موفق ثبت می‌شود. در غیر این صورت ارسال دوباره تلاش می‌شود (حداکثر ۹ بار و تا ۲ ساعت پس از ساخت درخواست).

## ویژگی‌ها

- پایش خودکار چند کیف‌پول ترون به‌طور هم‌زمان
- تشخیص تراکنش‌های جدید بر اساس `Last_Txid`
- صف ارسال Webhook با تلاش مجدد خودکار
- ثبت کامل جزئیات تراکنش‌ها در SQL Server
- ثبت لاگ‌ها و خطاها در فایل‌های XML
- رابط گرافیکی برای افزودن کیف‌پول، مشاهدهٔ کیف‌پول‌ها و نمایش زندهٔ لاگ عملیات
- ساختار آمادهٔ پشتیبانی از Ethereum (در حال حاضر فقط ترون پیاده‌سازی شده است)

## فناوری‌ها

| بخش | فناوری |
|-----|--------|
| زبان / چارچوب | C# · .NET Framework 4.6.1 |
| رابط کاربری | Windows Forms |
| پایگاه داده | SQL Server + Entity Framework 6.4 (Code First Migrations) |
| زمان‌بندی | DNTScheduler |
| ارتباط HTTP | HttpClient · Newtonsoft.Json |
| منبع داده بلاکچین | [TronScan API](https://apilist.tronscan.org/api/) |

## ساختار پروژه

```
GatewayTether/
├── Apis/          # BaseApi، TronApi (فراخوانی TronScan)، WebhookApi (ارسال Webhook)
├── Entities/      # DataContext و جداول: TblWallet، TblTransfer، TblWebhookRequest، TblError
├── Enums/         # CoinType (Tron, Ethereum)، TokenType (USDT)
├── Forms/         # HomeForm، AddWalletForm، WalletsForm
├── Helpers/       # توابع کمکی تاریخ، استثنا و Reflection
├── Migrations/    # Migrationهای EF
├── Models/        # مدل‌های داده برای API و Webhook
├── Repositories/  # دسترسی به داده (Wallet، Transfer، WebhookRequest، Error)
├── Schedules/     # CallTronScan (کار زمان‌بندی‌شده) و ScheduledTasksRegistry
├── Services/      # IScheduledTaskMessage (نمایش پیام در فرم اصلی)
└── XmlDocument/   # ثبت لاگ و خطا در فایل XML
```

## جداول پایگاه داده

- **TblWallet** — آدرس کیف‌پول، نوع کوین/توکن، آدرس Webhook، وضعیت فعال بودن و آخرین `Txid`
- **TblTransfer** — جزئیات کامل هر انتقال (فرستنده، گیرنده، مقدار، شناسه تراکنش، وضعیت تأیید و ...)
- **TblWebhookRequest** — صف ارسال Webhook (تعداد تلاش، وضعیت ارسال، آدرس مقصد)
- **TblError** — خطاهای ثبت‌شده

## قالب Webhook

برنامه به آدرس هر کیف‌پول یک درخواست `POST` با بدنهٔ JSON می‌فرستد. نمونهٔ ساختار:

```json
{
  "transaction_id": "…",
  "block_ts": 1650000000000,
  "from_address": "T…",
  "to_address": "T…",
  "contract_address": "T…",
  "quant": "1000000",
  "confirmed": true,
  "contractRet": "SUCCESS",
  "finalResult": "SUCCESS",
  "revert": false,
  "tokenInfo": { "tokenId": "…", "tokenAbbr": "USDT", "tokenName": "Tether USD" }
}
```

> نام دقیق فیلدها در `Models/TokenTransferModel.cs` تعریف شده است. مقدار `quant` بر اساس واحد کوچک توکن (۶ رقم اعشار برای USDT) است.

**پاسخ سرور شما** باید متن `ok` باشد تا ارسال موفق حساب شود.

## پیش‌نیازها

- Windows
- Visual Studio 2019/2022 با پشتیبانی از .NET Framework 4.6.1
- SQL Server (یا LocalDB)

## راه‌اندازی

۱. مخزن را کلون کنید:

```bash
git clone https://github.com/DiakoHasani/GatewayTether.git
```

۲. فایل `GatewayTether.sln` را در Visual Studio باز کنید و بسته‌های NuGet را بازیابی کنید.

۳. در `GatewayTether/App.config` دو مقدار را مطابق سیستم خود تنظیم کنید:

```xml
<appSettings>
  <add key="DocumentPath" value="C:\مسیر\پوشه\لاگ‌ها\" />
</appSettings>
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="data source=.;initial catalog=GatewayTetherDb;integrated security=true;MultipleActiveResultSets=True;App=EntityFramework"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

۴. پایگاه داده را بسازید. در Package Manager Console:

```powershell
Update-Database
```

۵. برنامه را اجرا کنید (`F5`). زمان‌بند با باز شدن فرم اصلی شروع به کار می‌کند.

۶. از دکمهٔ افزودن کیف‌پول، آدرس ترون و آدرس Webhook خود را وارد کنید.

## نکات و محدودیت‌ها

- فقط انتقال‌های **USDT روی ترون** پردازش می‌شود. Ethereum فعلاً فقط در Enum تعریف شده و پایش ندارد.
- زمان‌بندی روی ساعت «UTC + ۳:۳۰» (ایران) تنظیم شده است.
- بین پایش هر دو کیف‌پول ۱۰ ثانیه تأخیر هست تا محدودیت نرخ TronScan رد نشود.
- برای هر کیف‌پول فقط ۲۰ انتقال آخر بررسی می‌شود. اگر بین دو بار اجرا بیش از ۲۰ تراکنش برسد، ممکن است برخی از دست بروند.
- آدرس Webhook باید از سمت شما در دسترس باشد و در مدت کوتاه با `ok` پاسخ دهد.

## مشارکت

Pull Request و Issue خوش‌آمدند.

## مجوز

مجوز پروژه را اینجا مشخص کنید (مثلاً MIT).

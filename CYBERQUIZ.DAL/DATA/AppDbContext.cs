using CYBERQUIZ.DAL.MODELS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.DAL.DATA
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
        public DbSet<UserResult> UserResults => Set<UserResult>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Anropa base så att Identity-tabellerna konfigureras korrekt
            base.OnModelCreating(builder);

            
            // RELATIONER
            

            // Category → SubCategory: om en kategori tas bort raderas alla dess subkategorier
            builder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // SubCategory → Question: om en subkategori tas bort raderas alla dess frågor
            builder.Entity<SubCategory>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.SubCategory)
                .HasForeignKey(q => q.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Question → AnswerOption: om en fråga tas bort raderas alla dess svarsalternativ
            builder.Entity<Question>()
                .HasMany(q => q.AnswerOptions)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserResult → Question: Restrict så att en fråga inte kan raderas
            // om det finns sparade användarresultat kopplade till den
            builder.Entity<UserResult>()
                .HasOne(r => r.Question)
                .WithMany()
                .HasForeignKey(r => r.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index på UserId i UserResult för snabbare filtrering per användare
            builder.Entity<UserResult>()
                .HasIndex(r => r.UserId);

            // SEED-DATA
            // Körs vid Add-Migration och skapar initialt innehåll i databasen
            

            // Kategorier
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Nätverkssäkerhet" },
                new Category { Id = 2, Name = "Kryptering" },
                new Category { Id = 3, Name = "Autentisering" }
            );

            // Subkategorier – 3 per kategori
            builder.Entity<SubCategory>().HasData(
                // Nätverkssäkerhet
                new SubCategory { Id = 1, Name = "Brandväggar", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "VPN", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "DDoS-attacker", CategoryId = 1 },
                // Kryptering
                new SubCategory { Id = 4, Name = "Symmetrisk kryptering", CategoryId = 2 },
                new SubCategory { Id = 5, Name = "Asymmetrisk kryptering", CategoryId = 2 },
                new SubCategory { Id = 6, Name = "Hashning", CategoryId = 2 },
                // Autentisering
                new SubCategory { Id = 7, Name = "Lösenord", CategoryId = 3 },
                new SubCategory { Id = 8, Name = "Tvåfaktorsautentisering", CategoryId = 3 },
                new SubCategory { Id = 9, Name = "OAuth och SSO", CategoryId = 3 }
            );

            // Frågor – 10 per subkategori = 90 totalt
            builder.Entity<Question>().HasData(
                // Brandväggar (1-10)
                new Question { Id = 1, Text = "Vad är huvudsyftet med en brandvägg?", SubCategoryId = 1 },
                new Question { Id = 2, Text = "Vilket OSI-lager arbetar en paketfiltrerad brandvägg på?", SubCategoryId = 1 },
                new Question { Id = 3, Text = "Vad är en DMZ?", SubCategoryId = 1 },
                new Question { Id = 4, Text = "Vad är skillnaden mellan en stateful och stateless brandvägg?", SubCategoryId = 1 },
                new Question { Id = 5, Text = "Vad är en next-generation firewall (NGFW)?", SubCategoryId = 1 },
                new Question { Id = 6, Text = "Vilket påstående om brandväggsregler är korrekt?", SubCategoryId = 1 },
                new Question { Id = 7, Text = "Vad innebär 'default deny' i en brandväggspolicy?", SubCategoryId = 1 },
                new Question { Id = 8, Text = "Vad är en WAF?", SubCategoryId = 1 },
                new Question { Id = 9, Text = "Vilken typ av brandvägg inspekterar applikationslagret?", SubCategoryId = 1 },
                new Question { Id = 10, Text = "Vad menas med ingress- och egressfiltrering?", SubCategoryId = 1 },
                // VPN (11-20)
                new Question { Id = 11, Text = "Vad står VPN för?", SubCategoryId = 2 },
                new Question { Id = 12, Text = "Vilket protokoll används ofta för VPN-tunnlar?", SubCategoryId = 2 },
                new Question { Id = 13, Text = "Vad är skillnaden mellan site-to-site och remote access VPN?", SubCategoryId = 2 },
                new Question { Id = 14, Text = "Vad är split tunneling i VPN?", SubCategoryId = 2 },
                new Question { Id = 15, Text = "Vilket protokoll kombinerar AH och ESP?", SubCategoryId = 2 },
                new Question { Id = 16, Text = "Vad är en VPN-koncentrator?", SubCategoryId = 2 },
                new Question { Id = 17, Text = "Vad innebär SSL/TLS VPN?", SubCategoryId = 2 },
                new Question { Id = 18, Text = "Vilket lager i OSI arbetar IPSec på?", SubCategoryId = 2 },
                new Question { Id = 19, Text = "Vad är WireGuard?", SubCategoryId = 2 },
                new Question { Id = 20, Text = "Vad är en no-log policy i VPN?", SubCategoryId = 2 },
                // DDoS (21-30)
                new Question { Id = 21, Text = "Vad står DDoS för?", SubCategoryId = 3 },
                new Question { Id = 22, Text = "Vad är ett botnet?", SubCategoryId = 3 },
                new Question { Id = 23, Text = "Vad är en SYN flood-attack?", SubCategoryId = 3 },
                new Question { Id = 24, Text = "Vad är amplification attack?", SubCategoryId = 3 },
                new Question { Id = 25, Text = "Hur skiljer sig DoS från DDoS?", SubCategoryId = 3 },
                new Question { Id = 26, Text = "Vad är rate limiting?", SubCategoryId = 3 },
                new Question { Id = 27, Text = "Vad är en CDN och hur hjälper det mot DDoS?", SubCategoryId = 3 },
                new Question { Id = 28, Text = "Vad innebär blackhole routing?", SubCategoryId = 3 },
                new Question { Id = 29, Text = "Vilken attacktyp översvämmar nätverket med UDP-paket?", SubCategoryId = 3 },
                new Question { Id = 30, Text = "Vad är scrubbing center?", SubCategoryId = 3 },
                // Symmetrisk kryptering (31-40)
                new Question { Id = 31, Text = "Vilket är ett symmetriskt krypteringsalgoritm?", SubCategoryId = 4 },
                new Question { Id = 32, Text = "Hur många nycklar används vid symmetrisk kryptering?", SubCategoryId = 4 },
                new Question { Id = 33, Text = "Vad är nackdelen med symmetrisk kryptering?", SubCategoryId = 4 },
                new Question { Id = 34, Text = "Vad står AES för?", SubCategoryId = 4 },
                new Question { Id = 35, Text = "Vilken nyckellängd använder AES-256?", SubCategoryId = 4 },
                new Question { Id = 36, Text = "Vad är DES och varför används det inte längre?", SubCategoryId = 4 },
                new Question { Id = 37, Text = "Vad är ett block cipher?", SubCategoryId = 4 },
                new Question { Id = 38, Text = "Vad är ett stream cipher?", SubCategoryId = 4 },
                new Question { Id = 39, Text = "Vad är CBC-läge i kryptering?", SubCategoryId = 4 },
                new Question { Id = 40, Text = "Vad är Triple DES (3DES)?", SubCategoryId = 4 },
                // Asymmetrisk kryptering (41-50)
                new Question { Id = 41, Text = "Vilket är ett asymmetriskt krypteringsalgoritm?", SubCategoryId = 5 },
                new Question { Id = 42, Text = "Vad används den publika nyckeln till?", SubCategoryId = 5 },
                new Question { Id = 43, Text = "Vad används den privata nyckeln till?", SubCategoryId = 5 },
                new Question { Id = 44, Text = "Vad är PKI?", SubCategoryId = 5 },
                new Question { Id = 45, Text = "Vad är ett digitalt certifikat?", SubCategoryId = 5 },
                new Question { Id = 46, Text = "Vad är Diffie-Hellman?", SubCategoryId = 5 },
                new Question { Id = 47, Text = "Varför är asymmetrisk kryptering långsammare än symmetrisk?", SubCategoryId = 5 },
                new Question { Id = 48, Text = "Vad är ECC?", SubCategoryId = 5 },
                new Question { Id = 49, Text = "Vad är en digital signatur?", SubCategoryId = 5 },
                new Question { Id = 50, Text = "Vad är en CA (Certificate Authority)?", SubCategoryId = 5 },
                // Hashning (51-60)
                new Question { Id = 51, Text = "Vad är hashning?", SubCategoryId = 6 },
                new Question { Id = 52, Text = "Vilket av följande är en hashfunktion?", SubCategoryId = 6 },
                new Question { Id = 53, Text = "Vad är en kollision i hashning?", SubCategoryId = 6 },
                new Question { Id = 54, Text = "Vad är salting?", SubCategoryId = 6 },
                new Question { Id = 55, Text = "Varför används MD5 inte längre för lösenord?", SubCategoryId = 6 },
                new Question { Id = 56, Text = "Vad är bcrypt?", SubCategoryId = 6 },
                new Question { Id = 57, Text = "Vad är en regnbågstabell?", SubCategoryId = 6 },
                new Question { Id = 58, Text = "Vad är SHA-256?", SubCategoryId = 6 },
                new Question { Id = 59, Text = "Kan en hash reverseras?", SubCategoryId = 6 },
                new Question { Id = 60, Text = "Vad är HMAC?", SubCategoryId = 6 },
                // Lösenord (61-70)
                new Question { Id = 61, Text = "Vad är ett starkt lösenord?", SubCategoryId = 7 },
                new Question { Id = 62, Text = "Vad är en lösenordshanterare?", SubCategoryId = 7 },
                new Question { Id = 63, Text = "Vad är credential stuffing?", SubCategoryId = 7 },
                new Question { Id = 64, Text = "Vad är en brute force-attack?", SubCategoryId = 7 },
                new Question { Id = 65, Text = "Vad är en dictionary attack?", SubCategoryId = 7 },
                new Question { Id = 66, Text = "Varför ska man inte återanvända lösenord?", SubCategoryId = 7 },
                new Question { Id = 67, Text = "Vad är NIST:s rekommendation för lösenordslängd?", SubCategoryId = 7 },
                new Question { Id = 68, Text = "Vad innebär lösenordsrotation?", SubCategoryId = 7 },
                new Question { Id = 69, Text = "Vad är ett passphrase?", SubCategoryId = 7 },
                new Question { Id = 70, Text = "Hur lagras lösenord säkert i en databas?", SubCategoryId = 7 },
                // Tvåfaktorsautentisering (71-80)
                new Question { Id = 71, Text = "Vad är tvåfaktorsautentisering (2FA)?", SubCategoryId = 8 },
                new Question { Id = 72, Text = "Vilket är ett exempel på 2FA?", SubCategoryId = 8 },
                new Question { Id = 73, Text = "Vad är TOTP?", SubCategoryId = 8 },
                new Question { Id = 74, Text = "Vad är en hårdvarutoken?", SubCategoryId = 8 },
                new Question { Id = 75, Text = "Varför är SMS-baserad 2FA mindre säker?", SubCategoryId = 8 },
                new Question { Id = 76, Text = "Vad är en authenticator-app?", SubCategoryId = 8 },
                new Question { Id = 77, Text = "Vad är MFA?", SubCategoryId = 8 },
                new Question { Id = 78, Text = "Vad är en FIDO2-nyckel?", SubCategoryId = 8 },
                new Question { Id = 79, Text = "Vad är push-notifikationsautentisering?", SubCategoryId = 8 },
                new Question { Id = 80, Text = "Vad menas med 'something you know, something you have, something you are'?", SubCategoryId = 8 },
                // OAuth och SSO (81-90)
                new Question { Id = 81, Text = "Vad står OAuth för?", SubCategoryId = 9 },
                new Question { Id = 82, Text = "Vad är SSO?", SubCategoryId = 9 },
                new Question { Id = 83, Text = "Vad är skillnaden mellan autentisering och auktorisering?", SubCategoryId = 9 },
                new Question { Id = 84, Text = "Vad är ett access token i OAuth?", SubCategoryId = 9 },
                new Question { Id = 85, Text = "Vad är OpenID Connect?", SubCategoryId = 9 },
                new Question { Id = 86, Text = "Vad är SAML?", SubCategoryId = 9 },
                new Question { Id = 87, Text = "Vad är en refresh token?", SubCategoryId = 9 },
                new Question { Id = 88, Text = "Vad är OAuth 2.0 authorization code flow?", SubCategoryId = 9 },
                new Question { Id = 89, Text = "Vad är JWT?", SubCategoryId = 9 },
                new Question { Id = 90, Text = "Vad är en identity provider (IdP)?", SubCategoryId = 9 }
            );

            // Svarsalternativ – 4 per fråga, ett korrekt (IsCorrect = true)
            builder.Entity<AnswerOption>().HasData(
                // Fråga 1
                new AnswerOption { Id = 1, Text = "Filtrera nätverkstrafik och blockera obehörig åtkomst", IsCorrect = true, QuestionId = 1 },
                new AnswerOption { Id = 2, Text = "Öka internethastigheten", IsCorrect = false, QuestionId = 1 },
                new AnswerOption { Id = 3, Text = "Kryptera all datatrafik", IsCorrect = false, QuestionId = 1 },
                new AnswerOption { Id = 4, Text = "Lagra lösenord säkert", IsCorrect = false, QuestionId = 1 },
                // Fråga 2
                new AnswerOption { Id = 5, Text = "Lager 3 – Nätverkslagret", IsCorrect = true, QuestionId = 2 },
                new AnswerOption { Id = 6, Text = "Lager 1 – Fysiska lagret", IsCorrect = false, QuestionId = 2 },
                new AnswerOption { Id = 7, Text = "Lager 7 – Applikationslagret", IsCorrect = false, QuestionId = 2 },
                new AnswerOption { Id = 8, Text = "Lager 5 – Sessionslagret", IsCorrect = false, QuestionId = 2 },
                // Fråga 3
                new AnswerOption { Id = 9, Text = "Ett mellannät som isolerar publika tjänster från det interna nätverket", IsCorrect = true, QuestionId = 3 },
                new AnswerOption { Id = 10, Text = "En typ av kryptering", IsCorrect = false, QuestionId = 3 },
                new AnswerOption { Id = 11, Text = "Ett protokoll för VPN", IsCorrect = false, QuestionId = 3 },
                new AnswerOption { Id = 12, Text = "En metod för lösenordslagring", IsCorrect = false, QuestionId = 3 },
                // Fråga 4
                new AnswerOption { Id = 13, Text = "Stateful håller koll på anslutningens tillstånd, stateless gör det inte", IsCorrect = true, QuestionId = 4 },
                new AnswerOption { Id = 14, Text = "De är identiska", IsCorrect = false, QuestionId = 4 },
                new AnswerOption { Id = 15, Text = "Stateless är alltid säkrare", IsCorrect = false, QuestionId = 4 },
                new AnswerOption { Id = 16, Text = "Stateful används bara för UDP", IsCorrect = false, QuestionId = 4 },
                // Fråga 5
                new AnswerOption { Id = 17, Text = "En brandvägg som även inspekterar applikationslagret och har IPS-funktioner", IsCorrect = true, QuestionId = 5 },
                new AnswerOption { Id = 18, Text = "En brandvägg som bara filtrerar IP-adresser", IsCorrect = false, QuestionId = 5 },
                new AnswerOption { Id = 19, Text = "En brandvägg utan loggning", IsCorrect = false, QuestionId = 5 },
                new AnswerOption { Id = 20, Text = "En molnbaserad router", IsCorrect = false, QuestionId = 5 },
                // Fråga 6
                new AnswerOption { Id = 21, Text = "Regler utvärderas uppifrån och ner, första matchande regel gäller", IsCorrect = true, QuestionId = 6 },
                new AnswerOption { Id = 22, Text = "Alla regler utvärderas alltid", IsCorrect = false, QuestionId = 6 },
                new AnswerOption { Id = 23, Text = "Den sista regeln har högst prioritet", IsCorrect = false, QuestionId = 6 },
                new AnswerOption { Id = 24, Text = "Regler gäller bara för inkommande trafik", IsCorrect = false, QuestionId = 6 },
                // Fråga 7
                new AnswerOption { Id = 25, Text = "All trafik blockeras som standard om ingen regel tillåter den", IsCorrect = true, QuestionId = 7 },
                new AnswerOption { Id = 26, Text = "All trafik tillåts som standard", IsCorrect = false, QuestionId = 7 },
                new AnswerOption { Id = 27, Text = "Bara utgående trafik blockeras", IsCorrect = false, QuestionId = 7 },
                new AnswerOption { Id = 28, Text = "Brandväggen stängs av automatiskt", IsCorrect = false, QuestionId = 7 },
                // Fråga 8
                new AnswerOption { Id = 29, Text = "Web Application Firewall – skyddar webbapplikationer mot attacker som SQL injection", IsCorrect = true, QuestionId = 8 },
                new AnswerOption { Id = 30, Text = "En trådlös brandvägg", IsCorrect = false, QuestionId = 8 },
                new AnswerOption { Id = 31, Text = "En brandvägg för Windows", IsCorrect = false, QuestionId = 8 },
                new AnswerOption { Id = 32, Text = "En VPN-koncentrator", IsCorrect = false, QuestionId = 8 },
                // Fråga 9
                new AnswerOption { Id = 33, Text = "Proxy-brandvägg", IsCorrect = true, QuestionId = 9 },
                new AnswerOption { Id = 34, Text = "Paketfiltrerad brandvägg", IsCorrect = false, QuestionId = 9 },
                new AnswerOption { Id = 35, Text = "Stateless brandvägg", IsCorrect = false, QuestionId = 9 },
                new AnswerOption { Id = 36, Text = "Router", IsCorrect = false, QuestionId = 9 },
                // Fråga 10
                new AnswerOption { Id = 37, Text = "Ingress filtrerar inkommande trafik, egress filtrerar utgående trafik", IsCorrect = true, QuestionId = 10 },
                new AnswerOption { Id = 38, Text = "De är samma sak", IsCorrect = false, QuestionId = 10 },
                new AnswerOption { Id = 39, Text = "Ingress gäller bara för UDP", IsCorrect = false, QuestionId = 10 },
                new AnswerOption { Id = 40, Text = "Egress filtrerar inkommande trafik", IsCorrect = false, QuestionId = 10 },
                // Fråga 11
                new AnswerOption { Id = 41, Text = "Virtual Private Network", IsCorrect = true, QuestionId = 11 },
                new AnswerOption { Id = 42, Text = "Virtual Public Network", IsCorrect = false, QuestionId = 11 },
                new AnswerOption { Id = 43, Text = "Verified Private Node", IsCorrect = false, QuestionId = 11 },
                new AnswerOption { Id = 44, Text = "Virtual Protected Node", IsCorrect = false, QuestionId = 11 },
                // Fråga 12
                new AnswerOption { Id = 45, Text = "IPSec", IsCorrect = true, QuestionId = 12 },
                new AnswerOption { Id = 46, Text = "HTTP", IsCorrect = false, QuestionId = 12 },
                new AnswerOption { Id = 47, Text = "FTP", IsCorrect = false, QuestionId = 12 },
                new AnswerOption { Id = 48, Text = "SMTP", IsCorrect = false, QuestionId = 12 },
                // Fråga 13
                new AnswerOption { Id = 49, Text = "Site-to-site kopplar samman nätverk, remote access kopplar enskilda användare", IsCorrect = true, QuestionId = 13 },
                new AnswerOption { Id = 50, Text = "De är samma sak", IsCorrect = false, QuestionId = 13 },
                new AnswerOption { Id = 51, Text = "Remote access kopplar samman nätverk", IsCorrect = false, QuestionId = 13 },
                new AnswerOption { Id = 52, Text = "Site-to-site är snabbare", IsCorrect = false, QuestionId = 13 },
                // Fråga 14
                new AnswerOption { Id = 53, Text = "Delar upp trafiken så att bara viss trafik går via VPN", IsCorrect = true, QuestionId = 14 },
                new AnswerOption { Id = 54, Text = "Krypterar all trafik dubbelt", IsCorrect = false, QuestionId = 14 },
                new AnswerOption { Id = 55, Text = "Delar VPN-anslutningen mellan två användare", IsCorrect = false, QuestionId = 14 },
                new AnswerOption { Id = 56, Text = "En metod för att öka hastigheten", IsCorrect = false, QuestionId = 14 },
                // Fråga 15
                new AnswerOption { Id = 57, Text = "IPSec", IsCorrect = true, QuestionId = 15 },
                new AnswerOption { Id = 58, Text = "SSL", IsCorrect = false, QuestionId = 15 },
                new AnswerOption { Id = 59, Text = "TLS", IsCorrect = false, QuestionId = 15 },
                new AnswerOption { Id = 60, Text = "OpenVPN", IsCorrect = false, QuestionId = 15 },
                // Fråga 16
                new AnswerOption { Id = 61, Text = "En enhet som hanterar många VPN-anslutningar samtidigt", IsCorrect = true, QuestionId = 16 },
                new AnswerOption { Id = 62, Text = "En router med inbyggd brandvägg", IsCorrect = false, QuestionId = 16 },
                new AnswerOption { Id = 63, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 16 },
                new AnswerOption { Id = 64, Text = "En typ av switch", IsCorrect = false, QuestionId = 16 },
                // Fråga 17
                new AnswerOption { Id = 65, Text = "VPN som använder SSL/TLS-protokollet och fungerar via webbläsare", IsCorrect = true, QuestionId = 17 },
                new AnswerOption { Id = 66, Text = "VPN utan kryptering", IsCorrect = false, QuestionId = 17 },
                new AnswerOption { Id = 67, Text = "VPN som bara fungerar på mobila enheter", IsCorrect = false, QuestionId = 17 },
                new AnswerOption { Id = 68, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 17 },
                // Fråga 18
                new AnswerOption { Id = 69, Text = "Lager 3 – Nätverkslagret", IsCorrect = true, QuestionId = 18 },
                new AnswerOption { Id = 70, Text = "Lager 4 – Transportlagret", IsCorrect = false, QuestionId = 18 },
                new AnswerOption { Id = 71, Text = "Lager 7 – Applikationslagret", IsCorrect = false, QuestionId = 18 },
                new AnswerOption { Id = 72, Text = "Lager 2 – Datalänklagret", IsCorrect = false, QuestionId = 18 },
                // Fråga 19
                new AnswerOption { Id = 73, Text = "Ett modernt, snabbt och enkelt VPN-protokoll", IsCorrect = true, QuestionId = 19 },
                new AnswerOption { Id = 74, Text = "En brandväggstyp", IsCorrect = false, QuestionId = 19 },
                new AnswerOption { Id = 75, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 19 },
                new AnswerOption { Id = 76, Text = "En typ av router", IsCorrect = false, QuestionId = 19 },
                // Fråga 20
                new AnswerOption { Id = 77, Text = "VPN-leverantören sparar ingen information om användarens aktivitet", IsCorrect = true, QuestionId = 20 },
                new AnswerOption { Id = 78, Text = "Loggar raderas efter 30 dagar", IsCorrect = false, QuestionId = 20 },
                new AnswerOption { Id = 79, Text = "Alla anslutningar loggas men krypteras", IsCorrect = false, QuestionId = 20 },
                new AnswerOption { Id = 80, Text = "Bara metadata sparas", IsCorrect = false, QuestionId = 20 },
                // Fråga 21
                new AnswerOption { Id = 81, Text = "Distributed Denial of Service", IsCorrect = true, QuestionId = 21 },
                new AnswerOption { Id = 82, Text = "Direct Denial of Service", IsCorrect = false, QuestionId = 21 },
                new AnswerOption { Id = 83, Text = "Dynamic Denial of Service", IsCorrect = false, QuestionId = 21 },
                new AnswerOption { Id = 84, Text = "Distributed Data of Service", IsCorrect = false, QuestionId = 21 },
                // Fråga 22
                new AnswerOption { Id = 85, Text = "Ett nätverk av infekterade datorer som styrs av en angripare", IsCorrect = true, QuestionId = 22 },
                new AnswerOption { Id = 86, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 22 },
                new AnswerOption { Id = 87, Text = "En säker serverinfrastruktur", IsCorrect = false, QuestionId = 22 },
                new AnswerOption { Id = 88, Text = "Ett VPN-nätverk", IsCorrect = false, QuestionId = 22 },
                // Fråga 23
                new AnswerOption { Id = 89, Text = "En attack som översvämmar servern med TCP SYN-paket utan att slutföra handskakningen", IsCorrect = true, QuestionId = 23 },
                new AnswerOption { Id = 90, Text = "En attack mot DNS-servrar", IsCorrect = false, QuestionId = 23 },
                new AnswerOption { Id = 91, Text = "En attack som krypterar filer", IsCorrect = false, QuestionId = 23 },
                new AnswerOption { Id = 92, Text = "En attack mot lösenord", IsCorrect = false, QuestionId = 23 },
                // Fråga 24
                new AnswerOption { Id = 93, Text = "En attack som utnyttjar protokoll för att förstärka attacktrafiken mot målet", IsCorrect = true, QuestionId = 24 },
                new AnswerOption { Id = 94, Text = "En attack som krypterar nätverkstrafik", IsCorrect = false, QuestionId = 24 },
                new AnswerOption { Id = 95, Text = "En attack mot webbapplikationer", IsCorrect = false, QuestionId = 24 },
                new AnswerOption { Id = 96, Text = "En attack som stjäl lösenord", IsCorrect = false, QuestionId = 24 },
                // Fråga 25
                new AnswerOption { Id = 97, Text = "DoS kommer från en källa, DDoS från många källor samtidigt", IsCorrect = true, QuestionId = 25 },
                new AnswerOption { Id = 98, Text = "De är identiska", IsCorrect = false, QuestionId = 25 },
                new AnswerOption { Id = 99, Text = "DDoS är alltid svagare", IsCorrect = false, QuestionId = 25 },
                new AnswerOption { Id = 100, Text = "DoS kräver ett botnet", IsCorrect = false, QuestionId = 25 },
                // Fråga 26
                new AnswerOption { Id = 101, Text = "Begränsar antalet requests en användare kan göra under en tidsperiod", IsCorrect = true, QuestionId = 26 },
                new AnswerOption { Id = 102, Text = "Ökar nätverkshastigheten", IsCorrect = false, QuestionId = 26 },
                new AnswerOption { Id = 103, Text = "Krypterar nätverkstrafik", IsCorrect = false, QuestionId = 26 },
                new AnswerOption { Id = 104, Text = "Blockerar alla utländska IP-adresser", IsCorrect = false, QuestionId = 26 },
                // Fråga 27
                new AnswerOption { Id = 105, Text = "CDN distribuerar trafiken över många servrar globalt vilket minskar effekten av DDoS", IsCorrect = true, QuestionId = 27 },
                new AnswerOption { Id = 106, Text = "CDN krypterar all trafik", IsCorrect = false, QuestionId = 27 },
                new AnswerOption { Id = 107, Text = "CDN blockerar alla utländska anslutningar", IsCorrect = false, QuestionId = 27 },
                new AnswerOption { Id = 108, Text = "CDN ersätter brandväggen", IsCorrect = false, QuestionId = 27 },
                // Fråga 28
                new AnswerOption { Id = 109, Text = "Attacktrafik omdirigeras till en null-route och försvinner", IsCorrect = true, QuestionId = 28 },
                new AnswerOption { Id = 110, Text = "All trafik krypteras", IsCorrect = false, QuestionId = 28 },
                new AnswerOption { Id = 111, Text = "Servern stängs av automatiskt", IsCorrect = false, QuestionId = 28 },
                new AnswerOption { Id = 112, Text = "Trafiken omdirigeras till en backup-server", IsCorrect = false, QuestionId = 28 },
                // Fråga 29
                new AnswerOption { Id = 113, Text = "UDP flood", IsCorrect = true, QuestionId = 29 },
                new AnswerOption { Id = 114, Text = "SYN flood", IsCorrect = false, QuestionId = 29 },
                new AnswerOption { Id = 115, Text = "HTTP flood", IsCorrect = false, QuestionId = 29 },
                new AnswerOption { Id = 116, Text = "DNS amplification", IsCorrect = false, QuestionId = 29 },
                // Fråga 30
                new AnswerOption { Id = 117, Text = "En tjänst som filtrerar bort attacktrafik innan den når servern", IsCorrect = true, QuestionId = 30 },
                new AnswerOption { Id = 118, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 30 },
                new AnswerOption { Id = 119, Text = "En backup-datacenter", IsCorrect = false, QuestionId = 30 },
                new AnswerOption { Id = 120, Text = "En DNS-server", IsCorrect = false, QuestionId = 30 },
                // Fråga 31
                new AnswerOption { Id = 121, Text = "AES", IsCorrect = true, QuestionId = 31 },
                new AnswerOption { Id = 122, Text = "RSA", IsCorrect = false, QuestionId = 31 },
                new AnswerOption { Id = 123, Text = "ECC", IsCorrect = false, QuestionId = 31 },
                new AnswerOption { Id = 124, Text = "Diffie-Hellman", IsCorrect = false, QuestionId = 31 },
                // Fråga 32
                new AnswerOption { Id = 125, Text = "En nyckel", IsCorrect = true, QuestionId = 32 },
                new AnswerOption { Id = 126, Text = "Två nycklar", IsCorrect = false, QuestionId = 32 },
                new AnswerOption { Id = 127, Text = "Tre nycklar", IsCorrect = false, QuestionId = 32 },
                new AnswerOption { Id = 128, Text = "Ingen nyckel", IsCorrect = false, QuestionId = 32 },
                // Fråga 33
                new AnswerOption { Id = 129, Text = "Nyckeln måste delas säkert mellan parterna", IsCorrect = true, QuestionId = 33 },
                new AnswerOption { Id = 130, Text = "Den är för långsam", IsCorrect = false, QuestionId = 33 },
                new AnswerOption { Id = 131, Text = "Den kräver två nycklar", IsCorrect = false, QuestionId = 33 },
                new AnswerOption { Id = 132, Text = "Den kan inte kryptera stora filer", IsCorrect = false, QuestionId = 33 },
                // Fråga 34
                new AnswerOption { Id = 133, Text = "Advanced Encryption Standard", IsCorrect = true, QuestionId = 34 },
                new AnswerOption { Id = 134, Text = "Advanced Encryption System", IsCorrect = false, QuestionId = 34 },
                new AnswerOption { Id = 135, Text = "Asymmetric Encryption Standard", IsCorrect = false, QuestionId = 34 },
                new AnswerOption { Id = 136, Text = "Authenticated Encryption Standard", IsCorrect = false, QuestionId = 34 },
                // Fråga 35
                new AnswerOption { Id = 137, Text = "256 bitar", IsCorrect = true, QuestionId = 35 },
                new AnswerOption { Id = 138, Text = "128 bitar", IsCorrect = false, QuestionId = 35 },
                new AnswerOption { Id = 139, Text = "512 bitar", IsCorrect = false, QuestionId = 35 },
                new AnswerOption { Id = 140, Text = "64 bitar", IsCorrect = false, QuestionId = 35 },
                // Fråga 36
                new AnswerOption { Id = 141, Text = "DES har en för kort nyckel (56 bitar) och är lätt att knäcka med moderna datorer", IsCorrect = true, QuestionId = 36 },
                new AnswerOption { Id = 142, Text = "DES är för komplicerat att implementera", IsCorrect = false, QuestionId = 36 },
                new AnswerOption { Id = 143, Text = "DES stöds inte längre av moderna operativsystem", IsCorrect = false, QuestionId = 36 },
                new AnswerOption { Id = 144, Text = "DES kräver för mycket minne", IsCorrect = false, QuestionId = 36 },
                // Fråga 37
                new AnswerOption { Id = 145, Text = "Krypterar data i fasta block av en viss storlek", IsCorrect = true, QuestionId = 37 },
                new AnswerOption { Id = 146, Text = "Krypterar ett tecken i taget", IsCorrect = false, QuestionId = 37 },
                new AnswerOption { Id = 147, Text = "Använder alltid 256-bitars nycklar", IsCorrect = false, QuestionId = 37 },
                new AnswerOption { Id = 148, Text = "Är alltid snabbare än stream cipher", IsCorrect = false, QuestionId = 37 },
                // Fråga 38
                new AnswerOption { Id = 149, Text = "Krypterar data ett bit eller byte i taget", IsCorrect = true, QuestionId = 38 },
                new AnswerOption { Id = 150, Text = "Krypterar data i block", IsCorrect = false, QuestionId = 38 },
                new AnswerOption { Id = 151, Text = "Använder alltid asymmetrisk kryptering", IsCorrect = false, QuestionId = 38 },
                new AnswerOption { Id = 152, Text = "Är alltid säkrare än block cipher", IsCorrect = false, QuestionId = 38 },
                // Fråga 39
                new AnswerOption { Id = 153, Text = "Cipher Block Chaining – varje block XORas med föregående krypterade block", IsCorrect = true, QuestionId = 39 },
                new AnswerOption { Id = 154, Text = "En hashfunktion", IsCorrect = false, QuestionId = 39 },
                new AnswerOption { Id = 155, Text = "En asymmetrisk krypteringsmetod", IsCorrect = false, QuestionId = 39 },
                new AnswerOption { Id = 156, Text = "En typ av VPN-protokoll", IsCorrect = false, QuestionId = 39 },
                // Fråga 40
                new AnswerOption { Id = 157, Text = "Tillämpar DES-kryptering tre gånger för ökad säkerhet", IsCorrect = true, QuestionId = 40 },
                new AnswerOption { Id = 158, Text = "En helt ny krypteringsalgoritm", IsCorrect = false, QuestionId = 40 },
                new AnswerOption { Id = 159, Text = "Krypterar med tre olika algoritmer", IsCorrect = false, QuestionId = 40 },
                new AnswerOption { Id = 160, Text = "Använder 768-bitars nycklar", IsCorrect = false, QuestionId = 40 },
                // Fråga 41
                new AnswerOption { Id = 161, Text = "RSA", IsCorrect = true, QuestionId = 41 },
                new AnswerOption { Id = 162, Text = "AES", IsCorrect = false, QuestionId = 41 },
                new AnswerOption { Id = 163, Text = "DES", IsCorrect = false, QuestionId = 41 },
                new AnswerOption { Id = 164, Text = "Blowfish", IsCorrect = false, QuestionId = 41 },
                // Fråga 42
                new AnswerOption { Id = 165, Text = "Kryptera meddelanden som bara mottagaren kan dekryptera", IsCorrect = true, QuestionId = 42 },
                new AnswerOption { Id = 166, Text = "Dekryptera meddelanden", IsCorrect = false, QuestionId = 42 },
                new AnswerOption { Id = 167, Text = "Signera dokument", IsCorrect = false, QuestionId = 42 },
                new AnswerOption { Id = 168, Text = "Lagra lösenord", IsCorrect = false, QuestionId = 42 },
                // Fråga 43
                new AnswerOption { Id = 169, Text = "Dekryptera meddelanden och signera digitalt", IsCorrect = true, QuestionId = 43 },
                new AnswerOption { Id = 170, Text = "Kryptera meddelanden", IsCorrect = false, QuestionId = 43 },
                new AnswerOption { Id = 171, Text = "Dela med alla", IsCorrect = false, QuestionId = 43 },
                new AnswerOption { Id = 172, Text = "Skapa certifikat", IsCorrect = false, QuestionId = 43 },
                // Fråga 44
                new AnswerOption { Id = 173, Text = "Public Key Infrastructure – ett system för att hantera digitala certifikat och nycklar", IsCorrect = true, QuestionId = 44 },
                new AnswerOption { Id = 174, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 44 },
                new AnswerOption { Id = 175, Text = "Ett VPN-protokoll", IsCorrect = false, QuestionId = 44 },
                new AnswerOption { Id = 176, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 44 },
                // Fråga 45
                new AnswerOption { Id = 177, Text = "Ett elektroniskt dokument som binder en publik nyckel till en identitet", IsCorrect = true, QuestionId = 45 },
                new AnswerOption { Id = 178, Text = "En krypterad lösenordsfil", IsCorrect = false, QuestionId = 45 },
                new AnswerOption { Id = 179, Text = "En typ av hashfunktion", IsCorrect = false, QuestionId = 45 },
                new AnswerOption { Id = 180, Text = "En VPN-konfigurationsfil", IsCorrect = false, QuestionId = 45 },
                // Fråga 46
                new AnswerOption { Id = 181, Text = "Ett protokoll för säkert nyckelutbyte över ett osäkert nätverk", IsCorrect = true, QuestionId = 46 },
                new AnswerOption { Id = 182, Text = "En symmetrisk krypteringsalgoritm", IsCorrect = false, QuestionId = 46 },
                new AnswerOption { Id = 183, Text = "En hashfunktion", IsCorrect = false, QuestionId = 46 },
                new AnswerOption { Id = 184, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 46 },
                // Fråga 47
                new AnswerOption { Id = 185, Text = "Matematiska operationer med stora primtal är beräkningstungt", IsCorrect = true, QuestionId = 47 },
                new AnswerOption { Id = 186, Text = "Den använder längre nycklar alltid", IsCorrect = false, QuestionId = 47 },
                new AnswerOption { Id = 187, Text = "Den kräver mer minne", IsCorrect = false, QuestionId = 47 },
                new AnswerOption { Id = 188, Text = "Den krypterar mer data per operation", IsCorrect = false, QuestionId = 47 },
                // Fråga 48
                new AnswerOption { Id = 189, Text = "Elliptic Curve Cryptography – asymmetrisk kryptering med kortare nycklar och hög säkerhet", IsCorrect = true, QuestionId = 48 },
                new AnswerOption { Id = 190, Text = "En symmetrisk krypteringsalgoritm", IsCorrect = false, QuestionId = 48 },
                new AnswerOption { Id = 191, Text = "En hashfunktion", IsCorrect = false, QuestionId = 48 },
                new AnswerOption { Id = 192, Text = "En typ av VPN", IsCorrect = false, QuestionId = 48 },
                // Fråga 49
                new AnswerOption { Id = 193, Text = "En kryptografisk mekanism som verifierar avsändarens identitet och meddelandets integritet", IsCorrect = true, QuestionId = 49 },
                new AnswerOption { Id = 194, Text = "En elektronisk namnteckning i ett Word-dokument", IsCorrect = false, QuestionId = 49 },
                new AnswerOption { Id = 195, Text = "En typ av lösenord", IsCorrect = false, QuestionId = 49 },
                new AnswerOption { Id = 196, Text = "En hashfunktion", IsCorrect = false, QuestionId = 49 },
                // Fråga 50
                new AnswerOption { Id = 197, Text = "En betrodd organisation som utfärdar och signerar digitala certifikat", IsCorrect = true, QuestionId = 50 },
                new AnswerOption { Id = 198, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 50 },
                new AnswerOption { Id = 199, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 50 },
                new AnswerOption { Id = 200, Text = "En DNS-server", IsCorrect = false, QuestionId = 50 },
                // Fråga 51
                new AnswerOption { Id = 201, Text = "En envägsfunktion som omvandlar data till ett fast värde av bestämd längd", IsCorrect = true, QuestionId = 51 },
                new AnswerOption { Id = 202, Text = "En krypteringsmetod med nyckel", IsCorrect = false, QuestionId = 51 },
                new AnswerOption { Id = 203, Text = "En metod för att komprimera filer", IsCorrect = false, QuestionId = 51 },
                new AnswerOption { Id = 204, Text = "En typ av VPN", IsCorrect = false, QuestionId = 51 },
                // Fråga 52
                new AnswerOption { Id = 205, Text = "SHA-256", IsCorrect = true, QuestionId = 52 },
                new AnswerOption { Id = 206, Text = "AES", IsCorrect = false, QuestionId = 52 },
                new AnswerOption { Id = 207, Text = "RSA", IsCorrect = false, QuestionId = 52 },
                new AnswerOption { Id = 208, Text = "DES", IsCorrect = false, QuestionId = 52 },
                // Fråga 53
                new AnswerOption { Id = 209, Text = "När två olika indata ger samma hashvärde", IsCorrect = true, QuestionId = 53 },
                new AnswerOption { Id = 210, Text = "När en hash kan dekrypteras", IsCorrect = false, QuestionId = 53 },
                new AnswerOption { Id = 211, Text = "När hashfunktionen kraschar", IsCorrect = false, QuestionId = 53 },
                new AnswerOption { Id = 212, Text = "När salt-värdet är fel", IsCorrect = false, QuestionId = 53 },
                // Fråga 54
                new AnswerOption { Id = 213, Text = "Lägga till ett slumpmässigt värde till lösenordet innan hashning", IsCorrect = true, QuestionId = 54 },
                new AnswerOption { Id = 214, Text = "Kryptera hashen en extra gång", IsCorrect = false, QuestionId = 54 },
                new AnswerOption { Id = 215, Text = "Lagra lösenordet i klartext", IsCorrect = false, QuestionId = 54 },
                new AnswerOption { Id = 216, Text = "Använda ett längre lösenord", IsCorrect = false, QuestionId = 54 },
                // Fråga 55
                new AnswerOption { Id = 217, Text = "MD5 är kollisionsdrabbad och för snabb vilket gör den osäker för lösenord", IsCorrect = true, QuestionId = 55 },
                new AnswerOption { Id = 218, Text = "MD5 är för långsam", IsCorrect = false, QuestionId = 55 },
                new AnswerOption { Id = 219, Text = "MD5 stöds inte längre av operativsystem", IsCorrect = false, QuestionId = 55 },
                new AnswerOption { Id = 220, Text = "MD5 kräver för mycket minne", IsCorrect = false, QuestionId = 55 },
                // Fråga 56
                new AnswerOption { Id = 221, Text = "En lösenordshashfunktion med inbyggt salt och konfigurerbar kostnadsfaktor", IsCorrect = true, QuestionId = 56 },
                new AnswerOption { Id = 222, Text = "En symmetrisk krypteringsalgoritm", IsCorrect = false, QuestionId = 56 },
                new AnswerOption { Id = 223, Text = "En typ av VPN-protokoll", IsCorrect = false, QuestionId = 56 },
                new AnswerOption { Id = 224, Text = "En hashfunktion för filer", IsCorrect = false, QuestionId = 56 },
                // Fråga 57
                new AnswerOption { Id = 225, Text = "En förberäknad tabell med hashvärden för att knäcka lösenord", IsCorrect = true, QuestionId = 57 },
                new AnswerOption { Id = 226, Text = "En tabell med krypterade lösenord", IsCorrect = false, QuestionId = 57 },
                new AnswerOption { Id = 227, Text = "En typ av brandväggsregel", IsCorrect = false, QuestionId = 57 },
                new AnswerOption { Id = 228, Text = "En metod för nyckelutbyte", IsCorrect = false, QuestionId = 57 },
                // Fråga 58
                new AnswerOption { Id = 229, Text = "En kryptografisk hashfunktion som producerar ett 256-bitars hashvärde", IsCorrect = true, QuestionId = 58 },
                new AnswerOption { Id = 230, Text = "En symmetrisk krypteringsalgoritm", IsCorrect = false, QuestionId = 58 },
                new AnswerOption { Id = 231, Text = "En asymmetrisk krypteringsalgoritm", IsCorrect = false, QuestionId = 58 },
                new AnswerOption { Id = 232, Text = "En VPN-protokoll", IsCorrect = false, QuestionId = 58 },
                // Fråga 59
                new AnswerOption { Id = 233, Text = "Nej, hashning är en envägsfunktion som inte kan reverseras", IsCorrect = true, QuestionId = 59 },
                new AnswerOption { Id = 234, Text = "Ja, med rätt nyckel", IsCorrect = false, QuestionId = 59 },
                new AnswerOption { Id = 235, Text = "Ja, med tillräcklig datorkraft", IsCorrect = false, QuestionId = 59 },
                new AnswerOption { Id = 236, Text = "Ja, om salt-värdet är känt", IsCorrect = false, QuestionId = 59 },
                // Fråga 60
                new AnswerOption { Id = 237, Text = "Hash-based Message Authentication Code – verifierar meddelandets integritet och äkthet", IsCorrect = true, QuestionId = 60 },
                new AnswerOption { Id = 238, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 60 },
                new AnswerOption { Id = 239, Text = "En typ av digitalt certifikat", IsCorrect = false, QuestionId = 60 },
                new AnswerOption { Id = 240, Text = "En VPN-protokoll", IsCorrect = false, QuestionId = 60 },
                // Fråga 61
                new AnswerOption { Id = 241, Text = "Minst 12 tecken med stora/små bokstäver, siffror och specialtecken", IsCorrect = true, QuestionId = 61 },
                new AnswerOption { Id = 242, Text = "Ditt namn och födelseår", IsCorrect = false, QuestionId = 61 },
                new AnswerOption { Id = 243, Text = "Ett ord från en ordbok", IsCorrect = false, QuestionId = 61 },
                new AnswerOption { Id = 244, Text = "Samma lösenord på alla sidor", IsCorrect = false, QuestionId = 61 },
                // Fråga 62
                new AnswerOption { Id = 245, Text = "Ett program som lagrar och genererar starka lösenord säkert", IsCorrect = true, QuestionId = 62 },
                new AnswerOption { Id = 246, Text = "En webbläsartillägg för autofyll", IsCorrect = false, QuestionId = 62 },
                new AnswerOption { Id = 247, Text = "En anteckningsbok för lösenord", IsCorrect = false, QuestionId = 62 },
                new AnswerOption { Id = 248, Text = "En typ av 2FA", IsCorrect = false, QuestionId = 62 },
                // Fråga 63
                new AnswerOption { Id = 249, Text = "Att använda stulna användarnamn/lösenord från en dataintrång på andra tjänster", IsCorrect = true, QuestionId = 63 },
                new AnswerOption { Id = 250, Text = "En brute force-attack", IsCorrect = false, QuestionId = 63 },
                new AnswerOption { Id = 251, Text = "En phishing-attack", IsCorrect = false, QuestionId = 63 },
                new AnswerOption { Id = 252, Text = "En attack mot lösenordshashar", IsCorrect = false, QuestionId = 63 },
                // Fråga 64
                new AnswerOption { Id = 253, Text = "Systematiskt prova alla möjliga kombinationer tills rätt lösenord hittas", IsCorrect = true, QuestionId = 64 },
                new AnswerOption { Id = 254, Text = "Gissa lösenord med hjälp av personlig information", IsCorrect = false, QuestionId = 64 },
                new AnswerOption { Id = 255, Text = "Använda förberäknade hashvärden", IsCorrect = false, QuestionId = 64 },
                new AnswerOption { Id = 256, Text = "Avlyssna nätverkstrafik", IsCorrect = false, QuestionId = 64 },
                // Fråga 65
                new AnswerOption { Id = 257, Text = "En attack som provar ord från en ordlista som potentiella lösenord", IsCorrect = true, QuestionId = 65 },
                new AnswerOption { Id = 258, Text = "En attack som provar alla möjliga kombinationer", IsCorrect = false, QuestionId = 65 },
                new AnswerOption { Id = 259, Text = "En attack mot ordbokssidor", IsCorrect = false, QuestionId = 65 },
                new AnswerOption { Id = 260, Text = "En attack med stulna lösenord", IsCorrect = false, QuestionId = 65 },
                // Fråga 66
                new AnswerOption { Id = 261, Text = "Om ett lösenord stjäls kan angriparen komma åt alla konton med samma lösenord", IsCorrect = true, QuestionId = 66 },
                new AnswerOption { Id = 262, Text = "Det är svårare att komma ihåg", IsCorrect = false, QuestionId = 66 },
                new AnswerOption { Id = 263, Text = "Det strider mot GDPR", IsCorrect = false, QuestionId = 66 },
                new AnswerOption { Id = 264, Text = "Det gör inloggning långsammare", IsCorrect = false, QuestionId = 66 },
                // Fråga 67
                new AnswerOption { Id = 265, Text = "Minst 8 tecken, rekommenderat 15+ tecken", IsCorrect = true, QuestionId = 67 },
                new AnswerOption { Id = 266, Text = "Exakt 8 tecken", IsCorrect = false, QuestionId = 67 },
                new AnswerOption { Id = 267, Text = "Minst 20 tecken alltid", IsCorrect = false, QuestionId = 67 },
                new AnswerOption { Id = 268, Text = "Längden spelar ingen roll", IsCorrect = false, QuestionId = 67 },
                // Fråga 68
                new AnswerOption { Id = 269, Text = "Regelbundet byta lösenord för att minska risken vid ett intrång", IsCorrect = true, QuestionId = 68 },
                new AnswerOption { Id = 270, Text = "Använda samma lösenord på rotation", IsCorrect = false, QuestionId = 68 },
                new AnswerOption { Id = 271, Text = "Automatisk inloggning", IsCorrect = false, QuestionId = 68 },
                new AnswerOption { Id = 272, Text = "En typ av 2FA", IsCorrect = false, QuestionId = 68 },
                // Fråga 69
                new AnswerOption { Id = 273, Text = "En serie av slumpmässiga ord som används som lösenord", IsCorrect = true, QuestionId = 69 },
                new AnswerOption { Id = 274, Text = "Ett lösenord med specialtecken", IsCorrect = false, QuestionId = 69 },
                new AnswerOption { Id = 275, Text = "En PIN-kod", IsCorrect = false, QuestionId = 69 },
                new AnswerOption { Id = 276, Text = "Ett engångslösenord", IsCorrect = false, QuestionId = 69 },
                // Fråga 70
                new AnswerOption { Id = 277, Text = "Hashas med salt med en algoritm som bcrypt eller Argon2", IsCorrect = true, QuestionId = 70 },
                new AnswerOption { Id = 278, Text = "Lagras i klartext", IsCorrect = false, QuestionId = 70 },
                new AnswerOption { Id = 279, Text = "Krypteras med AES", IsCorrect = false, QuestionId = 70 },
                new AnswerOption { Id = 280, Text = "Lagras i en separat databas utan kryptering", IsCorrect = false, QuestionId = 70 },
                // Fråga 71
                new AnswerOption { Id = 281, Text = "En inloggningsmetod som kräver två olika typer av verifiering", IsCorrect = true, QuestionId = 71 },
                new AnswerOption { Id = 282, Text = "Att logga in med två lösenord", IsCorrect = false, QuestionId = 71 },
                new AnswerOption { Id = 283, Text = "En metod för att återställa lösenord", IsCorrect = false, QuestionId = 71 },
                new AnswerOption { Id = 284, Text = "Att använda två olika webbläsare", IsCorrect = false, QuestionId = 71 },
                // Fråga 72
                new AnswerOption { Id = 285, Text = "Lösenord + engångskod via SMS", IsCorrect = true, QuestionId = 72 },
                new AnswerOption { Id = 286, Text = "Användarnamn + lösenord", IsCorrect = false, QuestionId = 72 },
                new AnswerOption { Id = 287, Text = "E-post + användarnamn", IsCorrect = false, QuestionId = 72 },
                new AnswerOption { Id = 288, Text = "PIN-kod + PIN-kod", IsCorrect = false, QuestionId = 72 },
                // Fråga 73
                new AnswerOption { Id = 289, Text = "Time-based One-Time Password – engångslösenord som är giltigt i en kort tid", IsCorrect = true, QuestionId = 73 },
                new AnswerOption { Id = 290, Text = "En typ av VPN", IsCorrect = false, QuestionId = 73 },
                new AnswerOption { Id = 291, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 73 },
                new AnswerOption { Id = 292, Text = "En hashfunktion", IsCorrect = false, QuestionId = 73 },
                // Fråga 74
                new AnswerOption { Id = 293, Text = "En fysisk enhet som genererar engångslösenord", IsCorrect = true, QuestionId = 74 },
                new AnswerOption { Id = 294, Text = "En USB-minnesenhet", IsCorrect = false, QuestionId = 74 },
                new AnswerOption { Id = 295, Text = "En typ av smartkort", IsCorrect = false, QuestionId = 74 },
                new AnswerOption { Id = 296, Text = "En biometrisk sensor", IsCorrect = false, QuestionId = 74 },
                // Fråga 75
                new AnswerOption { Id = 297, Text = "SMS kan avlyssnas via SIM-swapping eller SS7-sårbarheter", IsCorrect = true, QuestionId = 75 },
                new AnswerOption { Id = 298, Text = "SMS är för långsamt", IsCorrect = false, QuestionId = 75 },
                new AnswerOption { Id = 299, Text = "SMS kräver internetanslutning", IsCorrect = false, QuestionId = 75 },
                new AnswerOption { Id = 300, Text = "SMS-koder är för korta", IsCorrect = false, QuestionId = 75 },
                // Fråga 76
                new AnswerOption { Id = 301, Text = "En app som genererar TOTP-koder för 2FA, t.ex. Google Authenticator", IsCorrect = true, QuestionId = 76 },
                new AnswerOption { Id = 302, Text = "En lösenordshanterare", IsCorrect = false, QuestionId = 76 },
                new AnswerOption { Id = 303, Text = "En VPN-klient", IsCorrect = false, QuestionId = 76 },
                new AnswerOption { Id = 304, Text = "En antivirusprogram", IsCorrect = false, QuestionId = 76 },
                // Fråga 77
                new AnswerOption { Id = 305, Text = "Multi-Factor Authentication – inloggning med fler än två faktorer", IsCorrect = true, QuestionId = 77 },
                new AnswerOption { Id = 306, Text = "Samma som 2FA", IsCorrect = false, QuestionId = 77 },
                new AnswerOption { Id = 307, Text = "En typ av VPN", IsCorrect = false, QuestionId = 77 },
                new AnswerOption { Id = 308, Text = "En krypteringsmetod", IsCorrect = false, QuestionId = 77 },
                // Fråga 78
                new AnswerOption { Id = 309, Text = "En hårdvarunyckel för lösenordsfri autentisering baserad på publik nyckelkryptering", IsCorrect = true, QuestionId = 78 },
                new AnswerOption { Id = 310, Text = "En typ av lösenordshanterare", IsCorrect = false, QuestionId = 78 },
                new AnswerOption { Id = 311, Text = "En VPN-nyckel", IsCorrect = false, QuestionId = 78 },
                new AnswerOption { Id = 312, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 78 },
                // Fråga 79
                new AnswerOption { Id = 313, Text = "En 2FA-metod där användaren godkänner inloggning via en notifikation i en app", IsCorrect = true, QuestionId = 79 },
                new AnswerOption { Id = 314, Text = "En SMS-baserad 2FA", IsCorrect = false, QuestionId = 79 },
                new AnswerOption { Id = 315, Text = "En e-postbaserad verifiering", IsCorrect = false, QuestionId = 79 },
                new AnswerOption { Id = 316, Text = "En biometrisk autentisering", IsCorrect = false, QuestionId = 79 },
                // Fråga 80
                new AnswerOption { Id = 317, Text = "De tre kategorierna av autentiseringsfaktorer: kunskap, ägande och biometri", IsCorrect = true, QuestionId = 80 },
                new AnswerOption { Id = 318, Text = "Tre typer av lösenord", IsCorrect = false, QuestionId = 80 },
                new AnswerOption { Id = 319, Text = "Tre nivåer av kryptering", IsCorrect = false, QuestionId = 80 },
                new AnswerOption { Id = 320, Text = "Tre typer av VPN", IsCorrect = false, QuestionId = 80 },
                // Fråga 81
                new AnswerOption { Id = 321, Text = "Open Authorization – ett protokoll för säker delegerad åtkomst", IsCorrect = true, QuestionId = 81 },
                new AnswerOption { Id = 322, Text = "Open Authentication", IsCorrect = false, QuestionId = 81 },
                new AnswerOption { Id = 323, Text = "Online Authorization", IsCorrect = false, QuestionId = 81 },
                new AnswerOption { Id = 324, Text = "Optional Authentication", IsCorrect = false, QuestionId = 81 },
                // Fråga 82
                new AnswerOption { Id = 325, Text = "Single Sign-On – logga in en gång och få åtkomst till flera tjänster", IsCorrect = true, QuestionId = 82 },
                new AnswerOption { Id = 326, Text = "Secure Sign-On", IsCorrect = false, QuestionId = 82 },
                new AnswerOption { Id = 327, Text = "Simple Sign-Out", IsCorrect = false, QuestionId = 82 },
                new AnswerOption { Id = 328, Text = "En typ av 2FA", IsCorrect = false, QuestionId = 82 },
                // Fråga 83
                new AnswerOption { Id = 329, Text = "Autentisering verifierar vem du är, auktorisering avgör vad du får göra", IsCorrect = true, QuestionId = 83 },
                new AnswerOption { Id = 330, Text = "De är samma sak", IsCorrect = false, QuestionId = 83 },
                new AnswerOption { Id = 331, Text = "Auktorisering verifierar vem du är", IsCorrect = false, QuestionId = 83 },
                new AnswerOption { Id = 332, Text = "Autentisering avgör vad du får göra", IsCorrect = false, QuestionId = 83 },
                // Fråga 84
                new AnswerOption { Id = 333, Text = "En tidsbegränsad nyckel som ger åtkomst till en resurs utan att dela lösenordet", IsCorrect = true, QuestionId = 84 },
                new AnswerOption { Id = 334, Text = "Ett permanent lösenord", IsCorrect = false, QuestionId = 84 },
                new AnswerOption { Id = 335, Text = "En krypteringsnyckel", IsCorrect = false, QuestionId = 84 },
                new AnswerOption { Id = 336, Text = "En typ av certifikat", IsCorrect = false, QuestionId = 84 },
                // Fråga 85
                new AnswerOption { Id = 337, Text = "Ett identitetslager ovanpå OAuth 2.0 för autentisering", IsCorrect = true, QuestionId = 85 },
                new AnswerOption { Id = 338, Text = "En ersättare för SAML", IsCorrect = false, QuestionId = 85 },
                new AnswerOption { Id = 339, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 85 },
                new AnswerOption { Id = 340, Text = "En typ av VPN", IsCorrect = false, QuestionId = 85 },
                // Fråga 86
                new AnswerOption { Id = 341, Text = "Security Assertion Markup Language – ett XML-baserat protokoll för SSO", IsCorrect = true, QuestionId = 86 },
                new AnswerOption { Id = 342, Text = "En krypteringsstandard", IsCorrect = false, QuestionId = 86 },
                new AnswerOption { Id = 343, Text = "En hashfunktion", IsCorrect = false, QuestionId = 86 },
                new AnswerOption { Id = 344, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 86 },
                // Fråga 87
                new AnswerOption { Id = 345, Text = "En långlivad token som används för att hämta nya access tokens", IsCorrect = true, QuestionId = 87 },
                new AnswerOption { Id = 346, Text = "En token som förnyar lösenordet", IsCorrect = false, QuestionId = 87 },
                new AnswerOption { Id = 347, Text = "En engångstoken", IsCorrect = false, QuestionId = 87 },
                new AnswerOption { Id = 348, Text = "En krypteringsnyckel", IsCorrect = false, QuestionId = 87 },
                // Fråga 88
                new AnswerOption { Id = 349, Text = "En OAuth-flöde där en kod utbyts mot tokens via en säker backend-kanal", IsCorrect = true, QuestionId = 88 },
                new AnswerOption { Id = 350, Text = "En inloggningsmetod med användarnamn och lösenord", IsCorrect = false, QuestionId = 88 },
                new AnswerOption { Id = 351, Text = "En typ av 2FA", IsCorrect = false, QuestionId = 88 },
                new AnswerOption { Id = 352, Text = "En krypteringsmetod", IsCorrect = false, QuestionId = 88 },
                // Fråga 89
                new AnswerOption { Id = 353, Text = "JSON Web Token – ett kompakt tokenformat för säker informationsöverföring", IsCorrect = true, QuestionId = 89 },
                new AnswerOption { Id = 354, Text = "Java Web Token", IsCorrect = false, QuestionId = 89 },
                new AnswerOption { Id = 355, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 89 },
                new AnswerOption { Id = 356, Text = "En typ av certifikat", IsCorrect = false, QuestionId = 89 },
                // Fråga 90
                new AnswerOption { Id = 357, Text = "En tjänst som hanterar och verifierar användaridentiteter, t.ex. Google eller Microsoft", IsCorrect = true, QuestionId = 90 },
                new AnswerOption { Id = 358, Text = "En typ av brandvägg", IsCorrect = false, QuestionId = 90 },
                new AnswerOption { Id = 359, Text = "En krypteringsalgoritm", IsCorrect = false, QuestionId = 90 },
                new AnswerOption { Id = 360, Text = "En DNS-server", IsCorrect = false, QuestionId = 90 }
            );
        }
    }
}

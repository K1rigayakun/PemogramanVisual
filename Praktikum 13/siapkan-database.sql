begin;

create table public.tugas_p13 (
    id uuid primary key default gen_random_uuid(),
    pemilik_id uuid not null references auth.users (id) on delete cascade,
    judul text not null check (char_length(btrim(judul)) between 1 and 100)
);

create index on public.tugas_p13 (pemilik_id);

alter table public.tugas_p13 enable row level security;

revoke all on public.tugas_p13 from public, anon, authenticated;
grant select on public.tugas_p13 to authenticated;
grant update (judul) on public.tugas_p13 to authenticated;

create policy "Baca tugas sendiri"
on public.tugas_p13 for select to authenticated
using ((select auth.uid()) = pemilik_id);

create policy "Ubah tugas sendiri"
on public.tugas_p13 for update to authenticated
using ((select auth.uid()) = pemilik_id)
with check ((select auth.uid()) = pemilik_id);

commit;

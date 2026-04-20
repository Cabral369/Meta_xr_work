VR Office Environment (Unity 6.3 LTS)

Projeto em Unity 6.3 LTS com uma cena de ambiente de escritório (low-poly), pensado para VR (Meta Quest) e build Android.

✨ Visão geral

A cena simula um escritório completo usando assets prontos (mobília, decoração, estrutura) e um conjunto de skyboxes para ambientação. O foco é servir como base para experiências VR (locomoção/interação) rodando em dispositivos Meta Quest via pipeline XR do Unity.

📦 Assets utilizados

Low-Poly Office Set #1 [+140 Models] [VNB]

AllSky Free - 10 Sky / Skybox Set

🧩 VR / XR Stack

O projeto foi configurado para VR com:

Meta XR All-in-One SDK (pacote "guarda-chuva" que agrega os SDKs Meta mais recentes).

XR Plug-in Management (framework do Unity para habilitar providers XR por plataforma, ex.: Android). A configuração "Android → Oculus" (ou equivalente) fica centralizada aqui.

Observação prática: a Meta recomenda OpenXR como backend padrão em Quest e o "Oculus XR Plugin"/packages relacionados como base para rodar no headset, dependendo do setup/versão do projeto.

🤖 Build alvo (Android / Meta Quest)

Plataforma alvo: Android (ou perfil Meta Quest quando disponível no Unity 6.x).

Para configurar/confirmar plataforma e XR no fluxo recomendado pela Meta (Build Profiles + OpenXR quando solicitado), use as orientações oficiais.

📞 Interação Obrigatória — Telefone Interativo

O projeto conta com um **telefone interativo** implementado em C# (`TelefoneInteracao.cs`).

**Como funciona:**
- Ao apontar o controller para o telefone e pressionar o **trigger**, o telefone toca o som de chamada em loop
- O monofone sobe levemente simulando a ação de atender
- Ao pressionar o trigger novamente, o som para e o monofone retorna à posição original

**Detalhes técnicos:**
- Input via `OVRInput` (Meta XR SDK)
- Detecção do objeto por `Physics.Raycast` a partir do controller
- Animação do monofone interpolada com `Vector3.Lerp`
- Áudio gerenciado pelo componente `AudioSource` da Unity com loop ativado

🗂️ Estrutura de pastas (Assets/)

A estrutura abaixo organiza o projeto por tipo de recurso (arte, áudio, scripts, cena) e por pacotes de terceiros:

Pasta	O que é / Para que serve

- Animation/	Clips, controllers (Animator), timelines e assets relacionados a animação.
- Audio/	Efeitos sonoros, músicas, mixers e configurações de áudio.
- HDRPDefaultResources/	Recursos padrão do HDRP (shaders, materiais e configs geradas/necessárias quando o projeto usa HDRP).
- Materials/	Materiais customizados do projeto (ex.: paredes, piso, variações do escritório).
- Models/	Modelos 3D (FBX/OBJ) próprios ou importados (fora dos pacotes de terceiros).
- Oculus/	Conteúdo importado/gerado relacionado ao ecossistema Meta/Oculus (dependendo do SDK/pacotes usados).
- Packages/	Conteúdo de terceiros mantido dentro do Assets (não confundir com Unity Package Manager). Aqui você agrupou: AllSkyFree/, VNB - Office Set/, XR/ etc.
- Packages/XR/Loaders e Packages/XR/Settings	Assets de configuração/carregadores XR que podem ser criados/atualizados conforme o XR Plug-in Management e providers ativos.
- Photons/	Area reservada para Photon (multiplayer/networking).
- Plugins/Android/	Plugins nativos Android (AAR, .so, manifest overrides). Padrão quando há integração com SDKs mobile/VR.
- Prefabs/	Prefabs do projeto (composição final de objetos da cena: paredes, salas, props, interações).
- Scripts/	Scripts C# do projeto (interações VR, lógica de cena, utilitários).

Link do projeto: https://github.com/Cabral369/Meta_xr_work

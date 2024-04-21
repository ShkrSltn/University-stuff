merge(List, List, []).
merge(List, [], List).

merge([MinList1|RestMerged], [MinList1|RestList1], [MinList2|RestList2]) :-
  MinList1 =< MinList2,
  merge(RestMerged,RestList1,[MinList2|RestList2]).
merge([MinList2|RestMerged], [MinList1|RestList1], [MinList2|RestList2]) :-
  MinList2 =< MinList1,
  merge(RestMerged,[MinList1|RestList1],RestList2).
% ----------------------------Соритров----------------------------------------С
% Сортировка слиянием

sliyaniyeSort([], []).
sliyaniyeSort([A], [A|[]]).

sliyaniyeSort(Sorted, List) :-
  length(List, N),
  FirstLength is //(N, 2),
  SecondLength is N - FirstLength,
  length(FirstUnsorted, FirstLength),
  length(SecondUnsorted, SecondLength),
  append(FirstUnsorted, SecondUnsorted, List),
  sliyaniyeSort(FirstSorted, FirstUnsorted),
  sliyaniyeSort(SecondSorted, SecondUnsorted),
  merge(Sorted, FirstSorted, SecondSorted).


%--------------------------------------------------------------------
%Соритровка два сортированных списков
%
sortLists([],L,L).
sortLists(L,[],L).
sortLists([Head1|Tail1], [Head2|Tail2], L) :-
    Head1 < Head2 -> L = [Head1|R], sortLists(Tail1,[Head2|Tail2],R) ;
    Head1 > Head2 -> L = [Head2|R], sortLists([Head1|Tail1],Tail2,R) ;
    L = [Head1,Head2|R], sortLists(Tail1,Tail2,R).
%------------------------------------------------------------------
%Соритровка выбором
%
viborSort([],[]).
viborSort([M1|S],[H|T]):-min(H,T,M1),remove(M1,[H|T],N),viborSort(S,N).

min(M,[],M).
min(M,[H|T],M1):-min2(M,H,N),min(N,T,M1).

min2(A,B,A):-less(A,B).
min2(A,B,B):-not(less(A,B)).

less(A,B):-(A<B).

append([],B,B).
append([H|A],B,[H|AB]):-append(A,B,AB).

remove(X,L,N):-append(A,[X|B],L),append(A,B,N).
%-------------------------------------------------------------------
%Проверка на упорядоченность
%
ordered( []      ) .
ordered( [_]     ) .
ordered( [X,Y|Z] ) :- X =< Y , ordered( [Y|Z] ) .
